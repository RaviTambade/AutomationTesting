
## 👨‍🏫 “From Manual Clicks to Smart Tests”

### 🧩 Scene 1 — The Manual Maze

> *“Imagine this…”*
> You’re a student tester logging in every morning —
> open Chrome → type the portal URL → enter email → password → click login → wait → click “Tests” → check details → start test…

Sounds familiar, right?
Now multiply that by 10 students, 5 SMEs, and 1 Admin.

Manual testing becomes a **ritual of repetition** — prone to mistakes, slow, and impossible to scale.

That’s when our team — Sanika, Sayali, Saloni, and Pradnya — realized something powerful:

> “If the browser is doing the same steps every time —
> why can’t we make the browser do it *for us*?”

That question is how *Automation Testing* was born in their learning journey.



### ⚙️ Scene 2 — Enter Selenium: The Invisible Tester

Selenium is like a **robot sitting inside Chrome**,
who can:

* open pages,
* click buttons,
* type in textboxes,
* and even validate if something changed — just like a human.

The only difference?
It never gets tired.

Our mission was simple:
**Automate the login and test workflow** of the `.NET TFL Assessment Portal`.



### 🧱 Scene 3 — Building the Automation Setup (Step-by-Step)

**Step 1: Create Project**

🧩 Java Maven Project → `TFLAssessmentTesting`
→ Add dependencies:

* `selenium-java`
* `webdrivermanager`
* `testng`

📄 `pom.xml` looked like this (simplified):

```xml
<dependencies>
   <dependency>
      <groupId>org.seleniumhq.selenium</groupId>
      <artifactId>selenium-java</artifactId>
      <version>4.13.0</version>
   </dependency>
   <dependency>
      <groupId>io.github.bonigarcia</groupId>
      <artifactId>webdrivermanager</artifactId>
      <version>5.3.2</version>
   </dependency>
   <dependency>
      <groupId>org.testng</groupId>
      <artifactId>testng</artifactId>
      <version>7.9.0</version>
   </dependency>
</dependencies>
```


**Step 2: Structure Your Tests**

We created folders for clarity:

```
TFLAssessmentTesting/
 ├── src/test/java/com/transflor/tfl/assessment/testing/
 │     ├── AdminLoginTest.java
 │     ├── SMELoginTest.java
 │     └── StudentLoginTest.java
 └── src/test/resources/testng.xml
```

Each file tests one user’s login process.

**Step 3: Launching Browser Automatically**

In the `@BeforeClass` setup:

```java
WebDriver driver;

@BeforeClass
public void setup() {
    WebDriverManager.chromedriver().setup();
    driver = new ChromeDriver();
    driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(10));
    driver.manage().window().maximize();
}
```

Now when you run the test — Chrome opens automatically! 🚀


**Step 4: Writing the Test Logic**

```java
@Test
public void studentLoginTest() {
    driver.get("http://localhost:8080/home.html");

    // Click Login
    driver.findElement(By.className("login-link")).click();

    // Enter credentials
    driver.findElement(By.id("email")).sendKeys("student1@example.com");
    driver.findElement(By.id("password")).sendKeys("password123");

    // Submit form
    driver.findElement(By.cssSelector("button[type='submit']")).click();

    // Validate login success
    String currentURL = driver.getCurrentUrl();
    Assert.assertTrue(currentURL.contains("/student/student.html"),
                      "Login failed for student!");
}
```

When run, the browser:

* opens the site
* fills in login form
* clicks “Login”
* verifies if redirected to `/student/student.html`

That’s automation in action 🧠💻


**Step 5: Closing the Browser**

```java
@AfterClass
public void tearDown() {
    driver.quit();
}
```

Browser closes automatically after each test — neat and clean!


### 🧠 Scene 4 — Asserts: The Judge of Truth

Sanika asked:

> “Sir, what is `Assert.assertTrue()`?”

It’s like saying —
“Check if what I expect is true.”

If the URL actually contains `/student/student.html`,
✅ the test *passes*.
Else, ❌ it *fails* — showing what went wrong.

Automation is not just *doing*, it’s also *verifying*.


### 🧭 Scene 5 — Expanding the Coverage

After successful login automation, the team extended tests for:

* SME Login and creating test schedules.
* Admin Login and assigning tests to students.
* Student logging in again and verifying assigned tests.

Each role had its own test script — like actors following the same script with different dialogues.


### 🧪 Scene 6 — Running Everything Together

`testng.xml`:

```xml
<suite name="TFL Assessment Automation Suite">
  <test name="All User Tests">
    <classes>
      <class name="com.transflor.tfl.assessment.testing.AdminLoginTest"/>
      <class name="com.transflor.tfl.assessment.testing.SMELoginTest"/>
      <class name="com.transflor.tfl.assessment.testing.StudentLoginTest"/>
    </classes>
  </test>
</suite>
```

Now, just one click → **Run Suite**
✅ Chrome opens → Admin logs in → SME logs in → Student logs in
All validations done automatically.

This is the **MBN Test Automation Framework** in motion.


### 🌟 Scene 7 — The Takeaway

> Manual testing is like walking through the forest every time.
> Automation builds you a path.

In today’s software engineering, Selenium testing builds **confidence** that what worked yesterday still works today.

And the best part?
It frees you to focus on **new features, not repeated clicks.**


### 💬 Mentor’s Final Words

> “When you automate, you don’t just test faster —
> you make your system *trustworthy*.”

