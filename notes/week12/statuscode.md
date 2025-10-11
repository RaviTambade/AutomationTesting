### 👨‍🏫 **Understanding HTTP Status Codes**

*(Scene: Morning session. Students are opening their laptops. Rutuja and Nikita are back in class.)*


**Rutuja:**
Sir, yesterday my API was working fine… but today it just says **404 Not Found**.
What’s that number even supposed to mean?

**Nikita:**
Yeah sir, I saw **500** once… then it magically disappeared. Feels like secret codes from aliens. 👽



**Mentor (smiling):**
Not aliens, Nikita — just **HTTP Status Codes**.
They’re the *language* web servers use to communicate with clients like browsers or APIs.

Imagine this —
you walk to your college admin office and ask:

> “Can I get my marksheet, please?”

The admin can respond in different ways:

* ✅ “Here it is.”
* 🚫 “Sorry, that record doesn’t exist.”
* 🔒 “You’re not authorized to see this.”
* 💥 “System crashed, try later.”

That’s **exactly** what HTTP status codes do between your browser (client) and server (admin office).



## 🌐 What is an HTTP Status Code?

Every time your browser or Postman makes an HTTP request — like `GET /students/1` —
the server replies not just with data, but also with a **status code**.

It’s a **3-digit number** that tells how the request went —
did it succeed, fail, redirect, or crash?


## 🧭 The 5 Families of Status Codes

| Category | Range   | Meaning       | Analogy                                      |
| -------- | ------- | ------------- | -------------------------------------------- |
| **1xx**  | 100–199 | Informational | “Hold on, I’m processing your request.”      |
| **2xx**  | 200–299 | Success       | “All good, here’s your data.”                |
| **3xx**  | 300–399 | Redirection   | “Hey, the thing you asked is now elsewhere.” |
| **4xx**  | 400–499 | Client Error  | “You messed up the request.”                 |
| **5xx**  | 500–599 | Server Error  | “The server messed up, not you.”             |


## 🟢 **2xx – Success Codes**

* **200 OK** → Request succeeded.
  *Example:* Getting list of products from `/api/products`.

* **201 Created** → New resource created successfully.
  *Example:* After `POST /api/users`, new user is added.

* **204 No Content** → Request succeeded but nothing to return.
  *Example:* After deleting a record — no body to send back.

## 🟡 **3xx – Redirection Codes**

* **301 Moved Permanently** → Resource is moved to new URL.
  *Example:* Old site redirects to new domain.

* **302 Found / Temporary Redirect** → Temporary change of location.
  *Example:* Login flow redirecting user.

* **304 Not Modified** → Cached data is still valid.
  *Example:* Browser uses cached image instead of downloading again.

## 🔴 **4xx – Client Error Codes**

* **400 Bad Request** → Invalid syntax or bad input.
  *Example:* Missing required fields in POST request.

* **401 Unauthorized** → Authentication required.
  *Example:* Accessing protected API without token.

* **403 Forbidden** → Authenticated but not allowed.
  *Example:* Student trying to view admin-only data.

* **404 Not Found** → Resource doesn’t exist.
  *Example:* `/students/99` when student 99 doesn’t exist.

* **409 Conflict** → Duplicate data or conflicting state.
  *Example:* Trying to create user with same email.

## 💀 **5xx – Server Error Codes**

* **500 Internal Server Error** → Generic crash.
  *Example:* Null reference or unhandled exception.

* **502 Bad Gateway** → Server got invalid response from another server.
  *Example:* API gateway to backend communication failed.

* **503 Service Unavailable** → Server overloaded or down for maintenance.
  *Example:* High traffic or database downtime.

* **504 Gateway Timeout** → One server waited too long for another.
  *Example:* Slow database or dependent API didn’t respond in time.

## 🧠 Mentor Tip:

When debugging APIs:

1. **200-series → smile 😄** (everything’s fine)
2. **300-series → follow the redirect**
3. **400-series → fix your request**
4. **500-series → fix your server**

**Nikita:**
Sir, so 404 is like “the admin doesn’t have my record,”
and 500 is like “the admin’s system crashed”?

**Mentor:**
Exactly! You’ve just learned to *read the heartbeat* of the web.
HTTP Status Codes are like a doctor’s report — they tell you what’s healthy and what’s broken.


**Rutuja (grinning):**
Now when I see 404, I’ll know it’s not an alien code —
it’s just the server saying, “Rutuja, I can’t find what you’re looking for!”

Perfect 🌟
Let’s continue the mentor story — but now, we’re walking into the **lab**.
Rutuja and Nikita have opened **Postman**, and we’ll actually *see* those mysterious numbers in action.
 

## 🧪 ** (Part 2): HTTP Status Codes in Action — Live in Postman**

*(Scene: Afternoon lab. The class projector shows Postman on screen.)*


**Mentor:**
Alright, warriors 👩‍💻👨‍💻 — theory time’s over. Let’s make these status codes *talk to us*.
You’ll see how each one tells a story.


### 🟢 1️⃣ **200 OK – The Happy Path**

**Mentor:**
Type this in Postman:

```
GET https://jsonplaceholder.typicode.com/users
```

**Nikita:**
Sir, I got a bunch of JSON data and status **200 OK** on the right corner!
So this means everything worked?

**Mentor:**
Exactly. The server is saying — “✅ Here’s what you asked for.”

🧩 **Usage in real apps:**
Fetching user details, product list, student records, etc.


### 🟢 2️⃣ **201 Created – When You Add Something**

**Mentor:**
Now let’s *create* a new resource.

```
POST https://jsonplaceholder.typicode.com/posts
```

**Body (JSON):**

```json
{
  "title": "MentorStory",
  "body": "HTTP Status Code session",
  "userId": 1
}
```

**Rutuja:**
Sir! The response says **201 Created** and shows a new `id`.

**Mentor:**
That’s the server celebrating — “🎉 I’ve created something new for you.”

🧩 **Usage:** When a new user, post, order, or record is successfully created.

### 🟡 3️⃣ **304 Not Modified – The Smart Saver**

**Mentor:**
Now suppose you open the same website again and again.
If the content hasn’t changed, the browser says,

> “Hey server, I already have this data. Is it still valid?”

If the server replies **304 Not Modified**, it means —
“👍 Yes, it’s still the same. Use your cached version.”

🧩 **Usage:** Improves performance by reducing unnecessary data transfer.


### 🔴 4️⃣ **400 Bad Request – The Student Mistake**

**Nikita:**
What if I send wrong data?

**Mentor:**
Let’s test that.

```
POST https://jsonplaceholder.typicode.com/posts
```

**Body:**

```json
{
  "title": ""
}
```

**Nikita:**
Ah! Status **400 Bad Request**.

**Mentor:**
That’s the server politely saying —
“👎 Your request doesn’t make sense. Please fix it.”

🧩 **Usage:** Validation errors, missing fields, or malformed JSON.

### 🔒 5️⃣ **401 Unauthorized – You Need a Pass!**

**Mentor:**
Let’s simulate authentication.

```
GET https://api.github.com/user
```

*(Without Authorization header)*

**Postman shows:**
`401 Unauthorized`

**Rutuja:**
So the API says I must log in first?

**Mentor:**
Exactly — just like college gate security.
You can’t enter without your ID card (token).

🧩 **Usage:** Token missing, invalid credentials, expired session.

### 🚫 6️⃣ **403 Forbidden – Access Denied**

**Mentor:**
Even if you’re logged in — you may not have permission.

Imagine Nikita trying to view *admin reports* with her *student* login.
The system says:

`403 Forbidden` —

> “You’re authenticated but not authorized.”

🧩 **Usage:** Role-based access control in APIs.


### 🔍 7️⃣ **404 Not Found – Missing Record**

**Mentor:**
Try:

```
GET https://jsonplaceholder.typicode.com/users/9999
```

**Nikita:**
Status **404 Not Found**, sir.

**Mentor:**
Exactly. The server looked but couldn’t find that resource.
Just like asking the librarian for a book that doesn’t exist.

🧩 **Usage:** Invalid URL, deleted data, or mistyped endpoints.



### 💥 8️⃣ **500 Internal Server Error – Server Crash**

**Rutuja:**
Sir, what about 500?

**Mentor:**
That’s the worst one — server-side error.
You can simulate it by running a buggy API in your local backend —
like dividing by zero or forgetting to handle exceptions.

Then the server shouts:

> “💣 Something broke on my side.”

🧩 **Usage:** Unhandled exceptions, database crashes, null references, etc.


### 🕓 9️⃣ **503 Service Unavailable – Maintenance Time**

**Mentor:**
When your favorite shopping site shows “We’ll be back soon,”
that’s often a **503 Service Unavailable** —
Server’s saying: “I’m overloaded or under maintenance.”

🧩 **Usage:** Heavy traffic, scheduled downtime.


## 🧠 **Mentor Wrap-Up:**

HTTP status codes are not random numbers.
They’re the **emotional language of the web**.
They tell your client how your server is *feeling* right now.

| Code | Meaning      | Emotion                      |
| ---- | ------------ | ---------------------------- |
| 200  | OK           | 😄 All good                  |
| 201  | Created      | 🎉 New thing added           |
| 400  | Bad Request  | 🤔 You sent something wrong  |
| 401  | Unauthorized | 🚷 Please log in             |
| 403  | Forbidden    | 🔒 You don’t have permission |
| 404  | Not Found    | 😕 Resource missing          |
| 500  | Server Error | 💥 I’m broken                |


**Nikita:**
So every time I test an API, I should check the status code first?

**Mentor:**
Exactly! That’s the first clue in any debugging mystery.
Before checking data, check the code — it tells you where the fault lies.

**Rutuja:**
Sir, HTTP status codes are like mood indicators of the server!

**Mentor (smiling):**
Well said, Rutuja. And remember —
Good engineers not only write APIs…
they *listen* to what the server is trying to say. 🧭

We’ll use both **ASP.NET Core** 🟦 *and* **Node.js (Express)** 🟩 examples so every student can try it in their stack.
Each route intentionally returns a specific **HTTP Status Code**, so they *feel* the meaning live.


## 🧪 **Mini Project Title:**

**“HTTP Status Code Playground”**

### 🎯 **Objective:**

Students will build a small REST API with multiple endpoints,
each demonstrating a specific HTTP status code in action.

They’ll learn how to:

* Return proper status codes from backend
* Write meaningful responses
* Test and verify with **Postman**



## 🟦 **Option 1: ASP.NET Core Web API (C#)**

### 🧰 Setup

```bash
dotnet new webapi -n StatusCodePlayground
cd StatusCodePlayground
dotnet run
```

### 🧩 Controller: `StatusController.cs`

```csharp
using Microsoft.AspNetCore.Mvc;

namespace StatusCodePlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        [HttpGet("ok")]
        public IActionResult GetOk() =>
            Ok(new { message = "Everything is fine (200 OK)" });

        [HttpPost("created")]
        public IActionResult Create() =>
            Created("/api/status/created", new { message = "Resource created (201 Created)" });

        [HttpGet("badrequest")]
        public IActionResult BadRequestExample() =>
            BadRequest(new { error = "Invalid request data (400 Bad Request)" });

        [HttpGet("unauthorized")]
        public IActionResult UnauthorizedExample() =>
            Unauthorized(new { error = "Please login first (401 Unauthorized)" });

        [HttpGet("forbidden")]
        public IActionResult ForbiddenExample() =>
            StatusCode(403, new { error = "You are not allowed here (403 Forbidden)" });

        [HttpGet("notfound")]
        public IActionResult NotFoundExample() =>
            NotFound(new { error = "Resource not found (404 Not Found)" });

        [HttpGet("servererror")]
        public IActionResult InternalServerError()
        {
            try
            {
                throw new Exception("Simulated server crash!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
```

### 🚀 Run and Test in Postman:

| Endpoint                   | Method | Expected Status           |
| -------------------------- | ------ | ------------------------- |
| `/api/status/ok`           | GET    | 200 OK                    |
| `/api/status/created`      | POST   | 201 Created               |
| `/api/status/badrequest`   | GET    | 400 Bad Request           |
| `/api/status/unauthorized` | GET    | 401 Unauthorized          |
| `/api/status/forbidden`    | GET    | 403 Forbidden             |
| `/api/status/notfound`     | GET    | 404 Not Found             |
| `/api/status/servererror`  | GET    | 500 Internal Server Error |



## 🟩 **Option 2: Node.js + Express**

### 🧰 Setup

```bash
mkdir status-code-playground
cd status-code-playground
npm init -y
npm install express
```

### 🧩 `server.js`

```javascript
const express = require("express");
const app = express();
app.use(express.json());

app.get("/ok", (req, res) => {
  res.status(200).json({ message: "Everything is fine (200 OK)" });
});

app.post("/created", (req, res) => {
  res.status(201).json({ message: "New resource created (201 Created)" });
});

app.get("/badrequest", (req, res) => {
  res.status(400).json({ error: "Invalid input (400 Bad Request)" });
});

app.get("/unauthorized", (req, res) => {
  res.status(401).json({ error: "Please login first (401 Unauthorized)" });
});

app.get("/forbidden", (req, res) => {
  res.status(403).json({ error: "Access denied (403 Forbidden)" });
});

app.get("/notfound", (req, res) => {
  res.status(404).json({ error: "Resource not found (404 Not Found)" });
});

app.get("/servererror", (req, res) => {
  try {
    throw new Error("Simulated server crash!");
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

const PORT = 3000;
app.listen(PORT, () => console.log(`Server running on port ${PORT}`));
```

### 🚀 Run and Test

```bash
node server.js
```

Then test:

```
GET http://localhost:3000/ok
GET http://localhost:3000/notfound
POST http://localhost:3000/created
```


## 💡 **Mentor Reflection Activity**

After testing all endpoints, ask each student:

| Question                                           | Reflection                                                               |
| -------------------------------------------------- | ------------------------------------------------------------------------ |
| What does each status code tell you as a client?   | 💭 “Server’s mood.”                                                      |
| Which codes are your responsibility (client-side)? | 4xx                                                                      |
| Which ones indicate server-side issues?            | 5xx                                                                      |
| Why is it important to return the correct code?    | Helps debugging, improves API documentation, enables front-end handling. |


## 🧠 **Extension Challenge**

Add two bonus endpoints:

* `/redirect` → Returns **302 Found** with a redirect to `/ok`
* `/nocontent` → Returns **204 No Content**



Bringing this **HTTP Status Code Playground** into **Spring Boot** makes it perfect for Java-track students!



## ☕ **Mini Project Title:**

### “HTTP Status Code Playground – Spring Boot Edition”

### 🎯 **Objective:**

Students will create a **Spring Boot REST API** that returns different HTTP status codes —
to understand how to use the right status in the right context.



## 🧰 **Step 1: Project Setup**

Create a new Spring Boot project (via [Spring Initializr](https://start.spring.io/) or IDE):

**Dependencies:**

* Spring Web
* (Optional) Spring Boot DevTools

**Project Metadata Example:**

```
Group: com.transflower
Artifact: statuscodeplayground
Name: StatusCodePlayground
```



## 📁 **Step 2: Directory Structure**

```
statuscodeplayground/
 ├─ src/main/java/com/transflower/statuscodeplayground/
 │   ├─ StatusCodePlaygroundApplication.java
 │   └─ controllers/
 │        └─ StatusController.java
 └─ pom.xml
```



## ⚙️ **Step 3: Main Application**

```java
package com.transflower.statuscodeplayground;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class StatusCodePlaygroundApplication {
    public static void main(String[] args) {
        SpringApplication.run(StatusCodePlaygroundApplication.class, args);
    }
}
```



## 🚀 **Step 4: Create the Controller**

```java
package com.transflower.statuscodeplayground.controllers;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Map;

@RestController
@RequestMapping("/api/status")
public class StatusController {

    @GetMapping("/ok")
    public ResponseEntity<Map<String, String>> ok() {
        return ResponseEntity.ok(Map.of("message", "Everything is fine (200 OK)"));
    }

    @PostMapping("/created")
    public ResponseEntity<Map<String, String>> created() {
        return ResponseEntity
                .status(HttpStatus.CREATED)
                .body(Map.of("message", "Resource created successfully (201 Created)"));
    }

    @GetMapping("/badrequest")
    public ResponseEntity<Map<String, String>> badRequest() {
        return ResponseEntity
                .badRequest()
                .body(Map.of("error", "Invalid request data (400 Bad Request)"));
    }

    @GetMapping("/unauthorized")
    public ResponseEntity<Map<String, String>> unauthorized() {
        return ResponseEntity
                .status(HttpStatus.UNAUTHORIZED)
                .body(Map.of("error", "Please login first (401 Unauthorized)"));
    }

    @GetMapping("/forbidden")
    public ResponseEntity<Map<String, String>> forbidden() {
        return ResponseEntity
                .status(HttpStatus.FORBIDDEN)
                .body(Map.of("error", "You are not allowed here (403 Forbidden)"));
    }

    @GetMapping("/notfound")
    public ResponseEntity<Map<String, String>> notFound() {
        return ResponseEntity
                .status(HttpStatus.NOT_FOUND)
                .body(Map.of("error", "Resource not found (404 Not Found)"));
    }

    @GetMapping("/servererror")
    public ResponseEntity<Map<String, String>> serverError() {
        try {
            int result = 10 / 0; // Force a crash
            return ResponseEntity.ok(Map.of("result", String.valueOf(result)));
        } catch (Exception ex) {
            return ResponseEntity
                    .status(HttpStatus.INTERNAL_SERVER_ERROR)
                    .body(Map.of("error", ex.getMessage()));
        }
    }

    @GetMapping("/nocontent")
    public ResponseEntity<Void> noContent() {
        return ResponseEntity.noContent().build();
    }

    @GetMapping("/redirect")
    public ResponseEntity<Void> redirect() {
        return ResponseEntity.status(HttpStatus.FOUND)
                .header("Location", "/api/status/ok")
                .build();
    }
}
```


## 🧪 **Step 5: Run the Application**

```bash
mvn spring-boot:run
```

Then open **Postman** or your browser and test these URLs:

| Endpoint                   | Method | Expected Status           | Description        |
| -------------------------- | ------ | ------------------------- | ------------------ |
| `/api/status/ok`           | GET    | 200 OK                    | Request successful |
| `/api/status/created`      | POST   | 201 Created               | New resource added |
| `/api/status/badrequest`   | GET    | 400 Bad Request           | Client-side error  |
| `/api/status/unauthorized` | GET    | 401 Unauthorized          | Missing auth       |
| `/api/status/forbidden`    | GET    | 403 Forbidden             | No permission      |
| `/api/status/notfound`     | GET    | 404 Not Found             | Resource missing   |
| `/api/status/servererror`  | GET    | 500 Internal Server Error | Server crashed     |
| `/api/status/nocontent`    | GET    | 204 No Content            | No data returned   |
| `/api/status/redirect`     | GET    | 302 Found                 | Redirect to /ok    |


## 💬 **Mentor Teaching Points**

When reviewing in class, ask:

* Why use **201** instead of **200** for POST?
* What’s the difference between **401 Unauthorized** and **403 Forbidden**?
* When would you purposely use **204 No Content**?
* What happens if you don’t handle exceptions (500s)?


## 🧠 **Extension Challenge**

Encourage students to:

1. Add a `/conflict` endpoint returning `409 Conflict`.
2. Add custom **GlobalExceptionHandler** using `@ControllerAdvice` to centralize all error responses.
3. Return structured error responses (e.g., timestamp, path, error message).




We’ll verify each endpoint’s response **status** and **message** in a *natural language* style that students can easily relate to.


## 🧠 **Concept Recap Before Code**

**Why BDD (Behavior-Driven Development)?**

As a mentor, you can say:

> “In BDD, we describe what the system *should do* in plain English — before we write the code.”

Then, those human-readable statements are connected to automated test scripts.

In our case:
✅ When I call `/api/status/ok`,
✅ I should receive status **200** and message **Everything is fine**.


## ⚙️ **Step 1: Add Dependencies in `pom.xml`**

Add these inside `<dependencies>`:

```xml
<!-- Cucumber + JUnit 5 -->
<dependency>
    <groupId>io.cucumber</groupId>
    <artifactId>cucumber-java</artifactId>
    <version>7.15.0</version>
    <scope>test</scope>
</dependency>

<dependency>
    <groupId>io.cucumber</groupId>
    <artifactId>cucumber-junit-platform-engine</artifactId>
    <version>7.15.0</version>
    <scope>test</scope>
</dependency>

<!-- Spring Boot Test -->
<dependency>
    <groupId>org.springframework.boot</groupId>
    <artifactId>spring-boot-starter-test</artifactId>
    <scope>test</scope>
</dependency>
```


## 🧩 **Step 2: Folder Structure**

```
src
 ├── main
 │    └── java/com/transflower/statuscodeplayground/...
 └── test
      ├── java/com/transflower/statuscodeplayground/stepdefs/
      │      ├── StatusStepDefinitions.java
      │      └── CucumberTestRunner.java
      └── resources/
             └── features/
                    └── statuscodes.feature
```


## 🧾 **Step 3: Feature File — `statuscodes.feature`**

```gherkin
Feature: HTTP Status Code Playground
  The API should return correct status codes for different endpoints

  Scenario: Verify 200 OK
    When I send GET request to "/api/status/ok"
    Then the response status should be 200
    And the response should contain "Everything is fine"

  Scenario: Verify 201 Created
    When I send POST request to "/api/status/created"
    Then the response status should be 201
    And the response should contain "Resource created"

  Scenario: Verify 404 Not Found
    When I send GET request to "/api/status/notfound"
    Then the response status should be 404
    And the response should contain "not found"

  Scenario: Verify 500 Internal Server Error
    When I send GET request to "/api/status/servererror"
    Then the response status should be 500
    And the response should contain "Simulated"
```



## 🧑‍💻 **Step 4: Step Definitions — `StatusStepDefinitions.java`**

```java
package com.transflower.statuscodeplayground.stepdefs;

import io.cucumber.java.en.And;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.web.server.LocalServerPort;
import org.springframework.http.*;
import org.springframework.web.client.RestTemplate;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest(webEnvironment = SpringBootTest.WebEnvironment.RANDOM_PORT)
public class StatusStepDefinitions {

    @LocalServerPort
    private int port;

    private ResponseEntity<String> response;

    private final RestTemplate restTemplate = new RestTemplate();

    @When("I send GET request to {string}")
    public void iSendGetRequestTo(String path) {
        String url = "http://localhost:" + port + path;
        response = restTemplate.getForEntity(url, String.class);
    }

    @When("I send POST request to {string}")
    public void iSendPostRequestTo(String path) {
        String url = "http://localhost:" + port + path;
        response = restTemplate.postForEntity(url, null, String.class);
    }

    @Then("the response status should be {int}")
    public void theResponseStatusShouldBe(int expectedStatus) {
        assertEquals(expectedStatus, response.getStatusCodeValue());
    }

    @And("the response should contain {string}")
    public void theResponseShouldContain(String expectedText) {
        assertTrue(response.getBody().toLowerCase().contains(expectedText.toLowerCase()));
    }
}
```


## 🚀 **Step 5: Cucumber Runner — `CucumberTestRunner.java`**

```java
package com.transflower.statuscodeplayground.stepdefs;

import io.cucumber.junit.platform.engine.Cucumber;

@Cucumber
public class CucumberTestRunner {
}
```


## 🧩 **Step 6: Run Tests**

In IntelliJ or Eclipse:

* Right-click `CucumberTestRunner.java`
* Choose **Run 'CucumberTestRunner'**

✅ You’ll see:

```
Scenario: Verify 200 OK -> PASSED
Scenario: Verify 201 Created -> PASSED
Scenario: Verify 404 Not Found -> PASSED
Scenario: Verify 500 Internal Server Error -> PASSED
```


## 🎓 **Mentor Wrap-Up Discussion**

When reviewing in class, ask:

| Question                                                    | Expected Learning                                           |
| ----------------------------------------------------------- | ----------------------------------------------------------- |
| What’s the benefit of describing tests in natural language? | Improves communication between devs, testers, and clients.  |
| Why use Cucumber for API testing?                           | It validates both behavior and response consistency.        |
| How does Spring Boot + BDD help teamwork?                   | Makes behavior-driven collaboration practical and testable. |

 

## 🧠 **Extension Challenge**

Encourage students to:

1. Add scenarios for `401 Unauthorized`, `403 Forbidden`, `204 No Content`.
2. Use `@DataTable` to feed multiple endpoints dynamically.
3. Integrate this suite with **GitHub Actions** or **Jenkins CI** to auto-run on each push.

 