const request = require("supertest"); //Library for testing HTTP servers
const app = require("../app"); 

describe("Secure web  api test", () => {   
    test('GET /api/userinfo should return user details', async () => {
        let token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MiwidXNlcm5hbWUiOiJzYW1lZXIiLCJpYXQiOjE3OTE0MDU3MDgsImV4cCI6MTc5MTQwOTMwOH0.f3lq6NiZFkQvPijNo0U_L5U2ruNExfRwgkeoZ4xhxPo";
        const response = await request(app)
                        .get('/api/userinfo')
                        .set("Authorization", `Bearer ${token}`);
        expect(response.statusCode).toBe(200);
        expect(response.body).toEqual({
            id: 2,
            username: "sameer"
        });
    });
});
