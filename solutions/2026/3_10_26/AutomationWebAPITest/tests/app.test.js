
const request = require("supertest"); //Library for testing HTTP servers
const app = require("../app");   // AUT: Application under test


describe("hello world api test", () => {
  

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

    test('POST /api/data should return the posted data', async () => {
        const postData = { name: 'John Doe', age: 30 };
        const response = await request(app).post('/api/data').send(postData);
        expect(response.statusCode).toBe(201);
        expect(response.body).toEqual(postData);
    });


});