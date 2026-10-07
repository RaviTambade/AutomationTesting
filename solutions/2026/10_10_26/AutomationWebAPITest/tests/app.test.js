const fs = require('fs');
const os = require('os');
const path = require('path');
const request = require('supertest');

const testDataDirectory = fs.mkdtempSync(path.join(os.tmpdir(), 'automation-web-api-'));
process.env.USERS_FILE = path.join(testDataDirectory, 'users.json');
process.env.JWT_SECRET = 'test-jwt-secret-with-at-least-32-characters';

const app = require('../app');

beforeEach(() => {
    fs.writeFileSync(process.env.USERS_FILE, '[]\n');
});

afterAll(() => {
    fs.rmSync(testDataDirectory, { recursive: true, force: true });
});

describe('public API routes', () => {
    test('GET / should return Hello World!', async () => {
        const response = await request(app).get('/');
        expect(response.statusCode).toBe(200);
        expect(response.text).toBe('Hello World!');
    });

    test('GET /api/health should return API status', async () => {

        const response = await request(app).get('/api/health');
        expect(response.statusCode).toBe(200);
        expect(response.body).toEqual({
            status: 'Success',
            message: 'API is running'
        });
    });

});

describe('authentication API', () => {
    const credentials = { email: 'jane@example.com', password: 'correct-horse-battery' };

    test('registers a user, stores a password hash, and returns a token', async () => {
        const response = await request(app).post('/api/auth/register').send(credentials);

        expect(response.statusCode).toBe(201);
        expect(response.body.user.email).toBe(credentials.email);
        expect(response.body.token).toEqual(expect.any(String));

        const users = JSON.parse(fs.readFileSync(process.env.USERS_FILE, 'utf8'));
        expect(users).toHaveLength(1);
        expect(users[0].passwordHash).not.toBe(credentials.password);
        expect(users[0]).not.toHaveProperty('password');
    });

    test('rejects invalid credentials and duplicate registration', async () => {
        await request(app).post('/api/auth/register').send(credentials);

        const duplicate = await request(app).post('/api/auth/register').send({
            email: credentials.email.toUpperCase(),
            password: credentials.password
        });
        const invalid = await request(app).post('/api/auth/register').send({
            email: 'not-an-email',
            password: 'short'
        });

        expect(duplicate.statusCode).toBe(409);
        expect(invalid.statusCode).toBe(400);
    });

    test('logs in with a matching password and rejects a wrong password', async () => {
        await request(app).post('/api/auth/register').send(credentials);

        const login = await request(app).post('/api/auth/login').send(credentials);
        const invalidLogin = await request(app).post('/api/auth/login').send({
            ...credentials,
            password: 'wrong-password'
        });

        expect(login.statusCode).toBe(200);
        expect(login.body.token).toEqual(expect.any(String));
        expect(invalidLogin.statusCode).toBe(401);
    });
});

describe('protected API routes', () => {
    test('requires a valid bearer token to post data', async () => {
        const postData = { name: 'John Doe', age: 30 };

        const unauthorized = await request(app).post('/api/data').send(postData);
        const invalidToken = await request(app)
            .post('/api/data')
            .set('Authorization', 'Bearer not-a-valid-token')
            .send(postData);
        const registration = await request(app).post('/api/auth/register').send({
            email: 'api-user@example.com',
            password: 'secure-password'
        });
        const authorized = await request(app)
            .post('/api/data')
            .set('Authorization', `Bearer ${registration.body.token}`)
            .send(postData);

        expect(unauthorized.statusCode).toBe(401);
        expect(invalidToken.statusCode).toBe(401);
        expect(authorized.statusCode).toBe(201);
        expect(authorized.body).toEqual(postData);
    });
});