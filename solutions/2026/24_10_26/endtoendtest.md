# Lab:  End-to-End Login Automation

Goal: Connect an HTML login page to a Node.js + Express Web API, then use Playwright to automate the complete login flow—from entering credentials to verifying the dashboard.

In the previous lab, login validation happened inside the HTML page. Now we’ll move authentication to the backend API, which is closer to a real application architecture.

## 1. Understand the architecture

```
        TRANSFLOWER LEARNING
   END-TO-END LOGIN AUTOMATION
   =================================


       +-----------------------------+
       |      HTML LOGIN PAGE        |
       |                             |
       |  Username:  ______________  |
       |  Password:  ______________  |
       |                             |
       |        [ Login ]            |
       +--------------+--------------+
                      |
                      |
                      | HTTP POST /api/login
                      | Content-Type: application/json
                      | Body: { username, password }
                      v
       +-----------------------------+
       |    NODE.JS + EXPRESS API    |
       |                             |
       |       /api/login            |
       |                             |
       |   Validate Credentials      |
       +--------------+--------------+
                      |
             +--------+--------+
             |                 |
             v                 v
   +------------------+  +------------------+
   | VALID CREDENTIALS|  | INVALID CREDENTIALS
   +--------+---------+  +--------+---------+
            |                     |
            v                     v
   +------------------+  +------------------+
   | HTTP 200 OK      |  | HTTP 401         |
   | Login Successful |  | Unauthorized     |
   +--------+---------+  +--------+---------+
            |                     |
            v                     v
   +------------------+  +------------------+
   |    DASHBOARD     |  |  ERROR MESSAGE    |
   |                  |  | Invalid username  |
   | Welcome Student! |  | or password       |
   +--------+---------+  +--------+---------+
            |                     |
            +----------+----------+
                       |
                       v
       +-----------------------------+
       |       PLAYWRIGHT TEST       |
       |                             |
       |  1. Fill username/password  |
       |  2. Click Login             |
       |  3. Verify API/UI behavior  |
       |  4. Assert expected result  |
       |                             |
       |  PASS / FAIL                |
       +-----------------------------+

```


Think of the HTML page as the reception desk and the Express API as the security office. The receptionist collects the details; the security office decides whether access is allowed.

## 2. Create the project

Install Node.js first, then run:

```
mkdir transflower-login-lab
cd transflower-login-lab

npm init -y
npm install express
npm install --save-dev @playwright/test
npx playwright install chromium
```

Create this folder structure:

```
transflower-login-lab/
│
├── server.js
├── public/
│   ├── login.html
│   └── dashboard.html
├── tests/
│   └── login.spec.js
└── package.json
```

Add a test script to `package.json`:

```
{
  "scripts": {
    "start": "node server.js",
    "test:e2e": "playwright test"
  }
}
```

If your generated `package.json` has other fields, keep them—just add the `scripts` entries.

## 3. Build the Express Web API

Create `server.js`:

```
const express = require('express');
const path = require('path');

const app = express();
const PORT = 3000;

app.use(express.json());
app.use(express.static(path.join(__dirname, 'public')));

// Demo-only credentials
const DEMO_USERNAME = 'valid_student';
const DEMO_PASSWORD = 'demo_password';

app.post('/api/login', (req, res) => {
    const { username, password } = req.body || {};

    if (!username || !password) {
        return res.status(400).json({
            success: false,
            message: 'Username and password are required'
        });
    }

    if (
        username === DEMO_USERNAME &&
        password === DEMO_PASSWORD
    ) {
        return res.status(200).json({
            success: true,
            message: 'Login successful',
            redirectUrl: '/dashboard.html'
        });
    }

    return res.status(401).json({
        success: false,
        message: 'Invalid username or password'
    });
});

app.listen(PORT, () => {
    console.log(`Transflower Login API running at http://localhost:${PORT}`);
});
```

What the API teaches us:

- `express.json()` reads JSON request bodies.
- `POST /api/login` accepts login credentials.
- HTTP `200` indicates successful demo authentication.
- HTTP `401` indicates invalid credentials.
- HTTP `400` indicates missing credentials.

## 4. Create the HTML login page

Create `public/login.html`:

```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Transflower Student Login</title>
</head>
<body>
    <h1>Transflower Learning</h1>
    <h2>Student Login</h2>

    <form id="loginForm">
        <div>
            <label for="username">Username</label>
            <input id="username" name="username"
                   type="text" autocomplete="username" required>
        </div>

        <div>
            <label for="password">Password</label>
            <input id="password" name="password"
                   type="password" autocomplete="current-password" required>
        </div>

        <button type="submit">Login</button>
    </form>

    <p id="message" role="status" aria-live="polite"></p>

    <script>
        const form = document.getElementById('loginForm');
        const message = document.getElementById('message');

        form.addEventListener('submit', async (event) => {
            event.preventDefault();
            message.textContent = 'Checking credentials...';

            try {
                const response = await fetch('/api/login', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        username: document.getElementById('username').value,
                        password: document.getElementById('password').value
                    })
                });

                const result = await response.json();

                if (!response.ok) {
                    message.textContent = result.message;
                    return;
                }

                window.location.href = result.redirectUrl;
            } catch (error) {
                message.textContent = 'Unable to connect to the server';
            }
        });
    </script>
</body>
</html>
```

The browser sends a real HTTP request to Express. It no longer decides whether the credentials are valid on its own.

## 5. Create the dashboard

Create `public/dashboard.html`:

```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Transflower Dashboard</title>
</head>
<body>
    <h1>Dashboard</h1>
    <p id="welcomeMessage">Welcome to Transflower Learning!</p>
</body>
</html>
```

This page is a simple demonstration target. It is not protected by authentication yet: because it is served as a static file, someone can navigate directly to its URL. In a production application, protect dashboard data and routes using server-validated sessions or another secure authentication mechanism.

## 6. Write Playwright end-to-end tests

Create `tests/login.spec.js`:

```
const { test, expect } = require('@playwright/test');

test.describe('Transflower Login E2E Tests', () => {

    test.beforeEach(async ({ page }) => {
        await page.goto('http://localhost:3000/login.html');
    });

    test('valid credentials should open dashboard', async ({ page }) => {
        await page.getByLabel('Username').fill('valid_student');
        await page.getByLabel('Password').fill('demo_password');

        await page.getByRole('button', { name: 'Login' }).click();

        await expect(page).toHaveURL(
            'http://localhost:3000/dashboard.html'
        );

        await expect(
            page.getByRole('heading', { name: 'Dashboard' })
        ).toBeVisible();

        await expect(
            page.locator('#welcomeMessage')
        ).toHaveText('Welcome to Transflower Learning!');
    });

    test('invalid credentials should display an error', async ({ page }) => {
        await page.getByLabel('Username').fill('wrong_student');
        await page.getByLabel('Password').fill('wrong_password');

        await page.getByRole('button', { name: 'Login' }).click();

        await expect(page.locator('#message'))
            .toHaveText('Invalid username or password');

        await expect(page).toHaveURL(
            'http://localhost:3000/login.html'
        );
    });

    test('empty fields should trigger browser validation', async ({ page }) => {
        await page.getByRole('button', { name: 'Login' }).click();

        await expect(page.getByLabel('Username'))
            .toBeFocused();

        await expect(page).toHaveURL(
            'http://localhost:3000/login.html'
        );
    });
});
```

The third test checks native browser form validation. The `required` fields prevent submission when empty, so the API should not receive a login request.

## 7. Run the application and tests

Open Terminal 1 to start the Express server:

```
npm start
```

Expected output:

```
Transflower Login API running at http://localhost:3000
```

Open Terminal 2 in the same project folder and run:

```
npm run test:e2e
```

To watch the browser execute the tests:

```
npx playwright test --headed
```

To open the Playwright HTML report after the test run:

```
npx playwright show-report
```

## 8. Understand what is being tested

| Test                | Expected result                      |
| ------------------- | ------------------------------------ |
| Valid credentials   | Dashboard opens                      |
| Invalid credentials | Error message appears                |
| Empty fields        | Browser blocks submission            |
| API unavailable     | Login page displays connection error |

This is an end-to-end test because it exercises the browser, HTML form, HTTP request, Express route, response handling, and resulting UI.

## 9. Debug the complete request flow

1. Playwright

Fill inputs and click Login

2. Browser JavaScript

Send `POST /api/login` with JSON

3. Express API

Validate the credentials and return HTTP status

4. Playwright Assertions

Verify URL, dashboard, or error message

If the test fails, inspect the server terminal first, then the browser console and network requests. Playwright can also capture API responses using `page.on('response', ...)` or wait for a particular response using `page.waitForResponse(...)`.

## 10. Mentor challenge

Try these extensions after the basic lab passes:

- Add an API test that verifies a `401` response for incorrect credentials.
- Verify the exact JSON response returned by `/api/login`.
- Capture a screenshot after successful login.
- Run the tests in Chromium, Firefox, and WebKit.
- Replace demo credentials with database-backed users, password hashing, and secure session-based authentication.

Important: The hard-coded credentials are for classroom use only. A production system must never rely on client-side authentication or plaintext hard-coded passwords.

A unit test can test a function. An API test can test a contract. An end-to-end test verifies that the pieces work together from the user's perspective.