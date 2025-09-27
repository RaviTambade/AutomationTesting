
### 🌍 The Online Shopping Experience

Imagine you and I are building a **Web Based E-Commerce Application**.
It has three layers:

1. **Web Portal (Frontend/UI)** – what customers see (React/Angular/ASP.NET MVC).
2. **Web API (Backend Services)** – the invisible waiter who takes requests from the UI and communicates with the kitchen.
3. **Database (Persistence)** – the kitchen pantry where all data (products, users, orders) is stored.

Now, let’s step into the shoes of a **customer**.

### 🧑‍💻 Customer Journey = End-to-End Flow

1. **Login/Register**

   * User opens the **Web Portal** and types username/password.
   * Portal sends this info to the **Web API**.
   * API checks with the **Database** whether the user exists.
   * Result comes back: ✅ Login successful.

   👉 *E2E Test Case*: Verify that when valid credentials are entered, the user gets logged in and redirected to their dashboard.


2. **Search & Browse Products**

   * User searches for “Wireless Headphones” on the **Web Portal**.
   * The portal calls the **Web API** `/products?search=headphones`.
   * API fetches matching data from the **Database** and returns a JSON response.
   * Portal shows the user all matching products.

   👉 *E2E Test Case*: Ensure search results display correctly, and product details match what’s in the database.

3. **Add to Cart**

   * User clicks **“Add to Cart”** on one product.
   * The Web Portal sends this request to the **API** (`/cart/add`).
   * API updates the **Database** (cart table).
   * Web Portal shows “Item added to cart”.

   👉 *E2E Test Case*: Verify that the product appears in the cart and database entry is created.

4. **Checkout & Payment**

   * User proceeds to checkout.
   * Web Portal calls **API** `/orders/create`.
   * API inserts an order into the **Database**, deducts inventory.
   * If payment gateway is involved, API interacts with it too.
   * Confirmation screen is shown.

   👉 *E2E Test Case*: Confirm that order is created in DB, inventory is updated, and confirmation message appears on the UI.


### 🔍 What E2E Testing Really Does

E2E testing doesn’t test just one **unit** (like API) or one **component** (like UI).
It verifies the **entire journey**, just like a **customer would use the system**.

* Unit Test = checking if “AddToCart()” function works in isolation.
* Integration Test = checking if API talks correctly with Database.
* **E2E Test = checking if user clicks button on UI, request flows through API, hits DB, and response comes back correctly.**

Think of it like:
👉 *We are not testing a car’s engine alone, nor the steering alone – we are driving the whole car on the road to see if everything works together.* 🚗💨


### ⚙️ Tools for E2E Testing

* **Selenium / Playwright** → Automate browser interactions (click, type, navigate).
* **RestAssured / Postman / Karate** → Validate API calls.
* **Database Assertions** → Direct SQL checks (to verify data).

So, a complete E2E test may look like:

✅ Open Web Portal → Login → Add to Cart → Checkout → Confirm Order → Check DB for correct order entry.



### 🏁 Takeaway for Students

End-to-End Testing = **walking in the shoes of the customer**, ensuring that from the **click on the UI** → through the **API requests** → down to the **database update**, everything works as one smooth flow.



## 📖 “From Manual Clicks to Automated End-to-End Tests”

Imagine we’re in our **Transflower Lab**.
We’ve just built a simple **Spring Boot application**. Inside it, we have:

* A **ProductsController** → Exposes REST endpoints:

  * `/api/products` → list all products
  * `/api/products/{id}` → get one product

* A **static index.html** → Shows products in a simple unordered list (`<ul><li>...</li></ul>`).

  * But! Instead of hardcoding, we used **JavaScript DOM manipulation** to fetch from `/api/products` and populate the list dynamically.

* This whole thing runs when we type:

```bash
mvn spring-boot:run
```

Tomcat starts. Our app is hosted on `localhost:9090`.
We open a browser → see the product list.
We open Postman → hit `/api/products` → see JSON response.
This is **manual testing**.

### 🔄 The Leap to Automation

I then turn to my students and ask:

> “Every time you run your app, will you **manually open a browser** and **manually hit Postman**? What if you need to run these checks 100 times a day, after every code change? Impossible!
> So, what do smart engineers do? They **automate** this process.”

And here comes our **two superheroes**:

1. **Selenium** → Automates **browser testing** (UI part).
2. **RestAssured** → Automates **API testing** (Postman replacement).

Both of them will be triggered by **TestNG**, and managed by **Maven Surefire plugin**.


### ⚙️ Step 1: Dependencies (pom.xml)

Inside our `pom.xml`:

```xml
<dependencies>
    <!-- Spring Boot Web -->
    <dependency>
        <groupId>org.springframework.boot</groupId>
        <artifactId>spring-boot-starter-web</artifactId>
    </dependency>

    <!-- TestNG -->
    <dependency>
        <groupId>org.testng</groupId>
        <artifactId>testng</artifactId>
        <version>7.8.0</version>
        <scope>test</scope>
    </dependency>

    <!-- Rest Assured -->
    <dependency>
        <groupId>io.rest-assured</groupId>
        <artifactId>rest-assured</artifactId>
        <version>5.4.0</version>
        <scope>test</scope>
    </dependency>

    <!-- Selenium -->
    <dependency>
        <groupId>org.seleniumhq.selenium</groupId>
        <artifactId>selenium-java</artifactId>
        <version>4.22.0</version>
        <scope>test</scope>
    </dependency>
</dependencies>
```

And yes, we configure **Surefire plugin** to pick up TestNG tests.


### ⚙️ Step 2: Test Suite (testng.xml)

In `src/test/resources/testng.xml`:

```xml
<!DOCTYPE suite SYSTEM "https://testng.org/testng-1.0.dtd" >
<suite name="E2E Test Suite">
    <test name="API Tests">
        <classes>
            <class name="com.example.catalog.test.ProductApiTest"/>
        </classes>
    </test>
    <test name="UI Tests">
        <classes>
            <class name="com.example.catalog.test.ProductUiTest"/>
        </classes>
    </test>
</suite>
```

So, one test class for **API**, one for **UI**.


### ⚙️ Step 3: API Test with RestAssured

```java
package com.example.catalog.test;

import io.restassured.RestAssured;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.Test;

import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.*;

public class ProductApiTest {

    @BeforeClass
    public void setup() {
        RestAssured.baseURI = "http://localhost:9090/api";
    }

    @Test
    public void getAllProducts_shouldReturnList() {
        given()
        .when()
            .get("/products")
        .then()
            .statusCode(200)
            .body("size()", greaterThan(0));
    }

    @Test
    public void getProductById_shouldReturnOne() {
        given()
        .when()
            .get("/products/1")
        .then()
            .statusCode(200)
            .body("name", notNullValue())
            .body("price", greaterThan(0));
    }
}
```

👉 This replaces **Postman testing** with automation.

 

### ⚙️ Step 4: UI Test with Selenium

```java
package com.example.catalog.test;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.Assert;
import org.testng.annotations.*;

import java.util.List;

public class ProductUiTest {

    WebDriver driver;

    @BeforeClass
    public void setup() {
        driver = new ChromeDriver(); // Make sure chromedriver is in PATH
    }

    @Test
    public void indexPage_shouldShowProductList() {
        driver.get("http://localhost:9090/index.html");

        List<WebElement> items = driver.findElements(By.tagName("li"));

        // Verify list is populated
        Assert.assertTrue(items.size() > 0, "Product list should not be empty");

        // Example: verify one product contains text "Headphones"
        boolean found = items.stream().anyMatch(e -> e.getText().contains("Headphones"));
        Assert.assertTrue(found, "Headphones should appear in product list");
    }

    @AfterClass
    public void teardown() {
        driver.quit();
    }
}
```

👉 This replaces **manual browser testing** with automation.

 

### 🌐 The Big Picture (E2E Flow)

So now, when we run:

```bash
mvn test
```

1. RestAssured tests → validate API responses.
2. Selenium tests → validate UI DOM + JavaScript rendering.
3. Together → They simulate what a **real customer** does: open browser, click, fetch products, see correct data.

That’s **End-to-End Testing** ✅

 

### 🎯 Mentor’s Closing Note

I always tell students:

> *“E2E tests are like a **dress rehearsal for your system**. You don’t test just the microphone or the stage light separately—you rehearse the whole play from start to finish. That’s when you know your system is production-ready.”*



## 📖  “CRUD – The Life Cycle of a Product”

I tell my students:

> “Every product in our catalog has a **life cycle**.
> It is **created (POST)**, later **read (GET)**, sometimes **updated (PUT)**, and finally may be **deleted (DELETE)**.
>
> End-to-End testing must cover this full journey.”

Now let’s see how **RestAssured** automates this entire cycle.



## ⚙️ ProductApiTest.java (Extended with CRUD)

```java
package com.example.catalog.test;

import io.restassured.RestAssured;
import io.restassured.http.ContentType;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.Test;

import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.*;

public class ProductApiTest {

    @BeforeClass
    public void setup() {
        RestAssured.baseURI = "http://localhost:9090/api";
    }

    // ✅ GET all products
    @Test
    public void getAllProducts_shouldReturnList() {
        given()
        .when()
            .get("/products")
        .then()
            .statusCode(200)
            .body("size()", greaterThan(0));
    }

    // ✅ GET one product by ID
    @Test
    public void getProductById_shouldReturnOne() {
        given()
        .when()
            .get("/products/1")
        .then()
            .statusCode(200)
            .body("name", notNullValue())
            .body("price", greaterThan(0));
    }

    // ✅ CREATE product (POST)
    @Test
    public void createProduct_shouldReturn201() {
        String newProductJson = """
        {
            "name": "Wireless Mouse",
            "price": 1500,
            "description": "Ergonomic wireless mouse",
            "category": "Electronics"
        }
        """;

        given()
            .contentType(ContentType.JSON)
            .body(newProductJson)
        .when()
            .post("/products")
        .then()
            .statusCode(201) // Created
            .body("id", notNullValue())
            .body("name", equalTo("Wireless Mouse"));
    }

    // ✅ UPDATE product (PUT)
    @Test
    public void updateProduct_shouldReturn200() {
        String updatedProductJson = """
        {
            "id": 1,
            "name": "Headphones - Updated",
            "price": 2200,
            "description": "Updated product description",
            "category": "Electronics"
        }
        """;

        given()
            .contentType(ContentType.JSON)
            .body(updatedProductJson)
        .when()
            .put("/products/1")
        .then()
            .statusCode(200)
            .body("name", equalTo("Headphones - Updated"))
            .body("price", equalTo(2200));
    }

    // ✅ DELETE product (DELETE)
    @Test
    public void deleteProduct_shouldReturn204() {
        given()
        .when()
            .delete("/products/2")
        .then()
            .statusCode(204); // No Content
    }
}
```



## 🔍 Walkthrough for Students

* **POST** → *Adds* a new product. We check if response has a new `id`.
* **GET** → Reads product list or single product details.
* **PUT** → *Updates* existing product. We assert name/price changed.
* **DELETE** → Removes a product. We check `204 No Content`.

👉 Together, this forms **CRUD automation**.



## 🌐 E2E Scenario with CRUD

When we run:

```bash
mvn test
```

The sequence validates:

1. Product list is **readable**.
2. A new product can be **added**.
3. An existing product can be **updated**.
4. A product can be **deleted**.

This proves our **Spring Boot API + DB layer** is working correctly from end-to-end.


## 🎯 Mentor’s Final Note

I tell my students:

> *“Unit tests are like checking the heartbeat of one organ.
> Integration tests are like checking two organs working together.
> But CRUD End-to-End tests? That’s like seeing if the full body can eat, digest, and grow stronger — the real sign of life!”*

 
