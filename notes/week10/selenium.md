 Perfect 👌 You’ve structured this like a **mini Selenium roadmap with practice-ready labs**. Let me continue in **mentor storytelling style** so it feels like I’m guiding you in a real lab session.

---

### 🌱 Mentor’s Voice

> “Ravi, imagine you’re training soldiers before sending them to the battlefield. Selenium is just like that — each feature you practice is a weapon in your automation toolkit. But don’t rush, one step at a time. Let’s go through the journey together.”

---

## 🚀 Step-by-Step Mini Tutorials (Your Learning Path)

### 1. **Forms & Input Fields**

* Scenario: Login form with text, password, file upload, and submit.
* **Skill gained**: Locating inputs, sending keystrokes, handling file upload.
* Practice: Build your `login.html`, automate login, assert success message.

👉 *Once you finish this, you will confidently automate any login form on a website.*

---

### 2. **Buttons & Alerts**

* Scenario: Buttons that trigger `alert()`, `confirm()`, `prompt()`.
* **Skill gained**: Switching to alert, reading text, accepting/dismissing, sending text.
* Practice: Trigger alert, assert text, accept/dismiss, handle prompt input.

👉 *After this, you won’t be afraid of those pesky pop-ups during automation runs.*

---

### 3. **Dropdowns & Checkboxes**

* Scenario: HTML `<select>` + multiple checkboxes.
* **Skill gained**: Using Selenium `Select`, selecting by text/value/index, verifying selection state.
* Practice: Write helper method `setCheckbox(locator, desiredState)` to always ensure the right state.

👉 *Now you’re ready for forms with dropdown menus, survey checkboxes, and preference pages.*

---

### 4. **Radio Buttons** (next natural step)

* Scenario: Gender selection (`Male/Female/Other`).
* **Skill gained**: Handling `isSelected()`, making sure only one radio stays checked.

👉 *You’ll be ready to handle surveys, registrations, and preference forms.*

---

### 5. **Tables & Dynamic Data**

* Scenario: An HTML table with rows of products.
* **Skill gained**: Traversing rows/columns, extracting text, verifying values.
* Practice: Locate a product row by name, assert its price.

👉 *This is the backbone for test reports, dashboards, or admin panels.*

---

### 6. **Frames & iFrames**

* Scenario: Embedded YouTube video or an ad inside a frame.
* **Skill gained**: `driver.switchTo().frame()`, `switchTo().defaultContent()`.

👉 *Crucial when dealing with banking apps, online editors, or embedded widgets.*

---

### 7. **Windows & Tabs**

* Scenario: Click link → opens in new tab/window.
* **Skill gained**: Handling multiple window handles, switching focus.

👉 *You’ll control websites that spawn multiple pages (social logins, payment gateways).*

---

### 8. **Waits & Synchronization**

* Scenario: AJAX search results that appear after a delay.
* **Skill gained**: Explicit waits (`ExpectedConditions`), polling, avoiding flaky tests.

👉 *This separates beginners from pros. You’ll stop using `Thread.sleep()` forever.*

---

### 9. **Screenshots & Reporting**

* Scenario: Capture screenshot when test fails.
* **Skill gained**: `TakesScreenshot`, saving images, embedding in reports.

👉 *Your tests will become production-grade and CI/CD-friendly.*

---

### 10. **Page Object Model (POM)**

* Scenario: Refactor login automation into a `LoginPage` class.
* **Skill gained**: Separating locators & actions, reusability, clean code.

👉 *This makes you industry-ready. All serious Selenium projects follow POM.*

---

⚡ **Final Project Idea:** Automate a **mini e-commerce app**:

* Login → Search for product → Add to cart → Checkout → Verify order confirmation.

This ties together **forms, buttons, alerts, dropdowns, checkboxes, tables, waits, screenshots, and POM** into one professional workflow.

---

👉 Question for you, Ravi:
Do you want me to expand **Radio Buttons → Tables → Frames → Windows → Waits** in the **same detailed format (HTML + Java + JUnit + Exercises)** like we did for Forms, Alerts, Dropdowns?

# Selenium — step-by-step mini-tutorials

## Prerequisites (quick)

1. Java (11+) installed.
2. Maven project with Selenium + JUnit + WebDriverManager (you already have this from earlier).
3. Chrome (or another browser) installed. WebDriverManager will download driver binary automatically.
4. Use explicit waits (WebDriverWait) instead of `Thread.sleep()` for reliability.

---

## A. Forms & Input Fields — login form (text, password, submit, file upload)

**Goal:** Open a page, enter username & password, upload a file, submit and verify success message.

### Sample HTML (save locally as `login.html` to test)

```html
<!doctype html>
<html>
<body>
  <form id="loginForm" action="#" onsubmit="document.getElementById('msg').innerText='Login successful'; return false;">
    <input id="username" name="username" type="text" />
    <input id="password" name="password" type="password" />
    <input id="file" name="file" type="file" />
    <button id="loginBtn" type="submit">Login</button>
  </form>
  <div id="msg"></div>
</body>
</html>
```

### Steps

1. `driver.get("file:///path/to/login.html")` or serve via local server.
2. Locate inputs (`By.id("username")`, `By.id("password")`) → `sendKeys(...)`.
3. For file input: `sendKeys("/full/path/to/file.txt")`.
4. Click submit (or `form.submit()`), wait for success message.
5. Assert expected message text.

### JUnit + Selenium snippet

```java
package com.example;

import io.github.bonigarcia.wdm.WebDriverManager;
import org.junit.jupiter.api.*;
import org.openqa.selenium.*;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.*;

import java.time.Duration;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class FormTest {
    static WebDriver driver;
    static WebDriverWait wait;

    @BeforeAll
    static void setup() {
        WebDriverManager.chromedriver().setup();
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, Duration.ofSeconds(10));
    }

    @Test
    void loginFormTest() {
        driver.get("file:///ABSOLUTE/PATH/TO/login.html");
        driver.findElement(By.id("username")).sendKeys("ravi");
        driver.findElement(By.id("password")).sendKeys("secret");
        driver.findElement(By.id("file")).sendKeys("/absolute/path/to/sample.txt");
        driver.findElement(By.id("loginBtn")).click();

        WebElement msg = wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("msg")));
        assertEquals("Login successful", msg.getText());
    }

    @AfterAll
    static void tearDown() {
        if (driver != null) driver.quit();
    }
}
```

### Exercises

* Add validation errors when username is empty; assert error message.
* Automate login against a demo app (e.g., some public test page) instead of local file.

### Common pitfalls

* File uploads require an **absolute path**.
* If element not interactable, wait for visibility/clickability before sendKeys/click.

---

## B. Handling Buttons & JavaScript Alerts (alert, confirm, prompt)

**Goal:** Click a button that triggers `alert()`, `confirm()` or `prompt()` and accept/dismiss/read text.

### Sample HTML

```html
<!doctype html>
<html>
<body>
  <button id="alertBtn" onclick="alert('Hello')">Alert</button>
  <button id="confirmBtn" onclick="if(confirm('OK?')) document.getElementById('c').innerText='OK'">Confirm</button>
  <button id="promptBtn" onclick="var t=prompt('Your name'); if(t) document.getElementById('p').innerText=t">Prompt</button>
  <div id="c"></div>
  <div id="p"></div>
</body>
</html>
```

### Steps

1. Click the alert/confirm/prompt button.
2. Switch to alert: `Alert a = driver.switchTo().alert()`.
3. Use `a.getText()`, `a.accept()` (OK), `a.dismiss()` (Cancel), `a.sendKeys("...")` (prompt).
4. Assert page change or alert text.

### Code snippet

```java
@Test
void alertsTest() {
    driver.get("file:///ABSOLUTE/PATH/TO/alerts.html");

    // alert
    driver.findElement(By.id("alertBtn")).click();
    Alert a = wait.until(ExpectedConditions.alertIsPresent());
    assertEquals("Hello", a.getText());
    a.accept();

    // confirm -> accept
    driver.findElement(By.id("confirmBtn")).click();
    a = wait.until(ExpectedConditions.alertIsPresent());
    a.accept();
    WebElement c = driver.findElement(By.id("c"));
    assertEquals("OK", c.getText());

    // prompt -> send keys
    driver.findElement(By.id("promptBtn")).click();
    a = wait.until(ExpectedConditions.alertIsPresent());
    a.sendKeys("Ravi");
    a.accept();
    assertEquals("Ravi", driver.findElement(By.id("p")).getText());
}
```

### Exercises

* Dismiss a confirm and assert no change.
* Test alert text contains expected phrase.

### Pitfalls

* Alert not present → `NoAlertPresentException`; use `WebDriverWait` `alertIsPresent()`.
* Modal dialogs from OS (not JS) cannot be handled by Selenium.

---

## C. Dropdowns & Checkboxes (selects, multi-select, isSelected)

**Goal:** Select options by visible text/value/index, check/uncheck boxes, assert selection state.

### Sample HTML

```html
<!doctype html>
<html>
<body>
  <select id="cars">
    <option value="volvo">Volvo</option>
    <option value="saab">Saab</option>
    <option value="mercedes">Mercedes</option>
  </select>

  <input type="checkbox" id="cb1" />
  <input type="checkbox" id="cb2" checked />
</body>
</html>
```

### Steps

1. For `<select>` use Selenium `Select` helper: `Select s = new Select(elem)`.
2. Use `s.selectByVisibleText("Saab")` or `s.selectByValue("saab")`.
3. For multiple select use `s.selectByIndex(...)` and `s.getAllSelectedOptions()`.
4. For checkbox: check `isSelected()` before click to ensure desired final state.

### Code snippet

```java
@Test
void dropdownAndCheckboxTest() {
    driver.get("file:///ABSOLUTE/PATH/TO/selects.html");

    Select cars = new Select(driver.findElement(By.id("cars")));
    cars.selectByVisibleText("Saab");
    assertEquals("Saab", cars.getFirstSelectedOption().getText());

    WebElement cb1 = driver.findElement(By.id("cb1"));
    if (!cb1.isSelected()) cb1.click();
    assertTrue(cb1.isSelected());

    WebElement cb2 = driver.findElement(By.id("cb2"));
    if (cb2.isSelected()) cb2.click(); // uncheck
    assertTrue(!cb2.isSelected());
}
```

### Exercises

* Automate a multi-select list: select multiple items and assert count of selected options.
* Implement a helper method `setCheckbox(By locator, boolean desiredState)`.

### Pitfalls

* Some dropdowns are custom-styled (not `<select>`). Then you must click the visible elements (li/div) — treat like normal elements, not `Select`.
* Clicking a checkbox that’s off-screen may throw `ElementClickInterceptedException` — scroll into view or wait.

---

## Extra essentials & best practices (next steps)

* **Locators first:** prefer `id`, `name`, `data-*` attributes → then CSS selectors → then XPath.
* **Use explicit waits** (`WebDriverWait` + `ExpectedConditions`) for visibility/clickability.
* **Page Object Model (POM):** move page locators & actions into page classes for maintainability.
* **Avoid brittle tests:** avoid absolute XPaths, avoid relying on timing; mock flaky network if possible.
* **Run headless for CI:** use `ChromeOptions().addArguments("--headless=new")` for non-GUI runs.
* **Parallel tests:** later use TestNG or JUnit 5 parallel execution configs + separate driver instances.
* **Data-driven testing:** parameterize tests (CSV, JSON, or JUnit param provider).

---

## Quick checklist for each practice test

1. Can you locate the element reliably? (yes/no)
2. Do you wait for element state (visible/clickable)?
3. Is the action (click/sendKeys) robust?
4. Is there an assertion that verifies behavior?
5. Is test isolated (clean state between tests)?

 