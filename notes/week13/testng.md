### **1️⃣ What is TestNG?**

**TestNG** stands for **“Test Next Generation”**. It is a **testing framework for Java**, inspired by JUnit but with more powerful features.

So yes, **TestNG is a framework**. Specifically, it is used for **unit testing, functional testing, integration testing, and end-to-end testing** in Java applications.

### **2️⃣ Role of TestNG in Java Testing**

TestNG helps automate the testing process and makes your tests:

1. **Structured & Organized**

   * You can group tests into classes, packages, or suites.
   * Provides **annotations** like `@Test`, `@BeforeMethod`, `@AfterMethod` to define the lifecycle of tests.

2. **Flexible Test Execution**

   * Run tests in **parallel** to reduce execution time.
   * Run tests **selectively** using `groups` or `include/exclude` filters in `testng.xml`.

3. **Powerful Reporting**

   * Generates **HTML and XML reports** automatically.
   * Helps track which tests passed, failed, or were skipped.

4. **Dependency Management**

   * You can specify **test dependencies**. For example, run `testB` only if `testA` succeeds using `dependsOnMethods`.

5. **Data-Driven Testing**

   * Supports **@DataProvider** to pass multiple data sets to a single test method.

6. **Integration with Tools**

   * Works with **Maven, Gradle, Jenkins**, Selenium WebDriver, and more.
   * This makes it very useful for **automation testing of Java applications**, especially web apps.

### **3️⃣ Key Features that Make TestNG a Framework**

| Feature               | Description                                                 |
| --------------------- | ----------------------------------------------------------- |
| Annotations           | `@Test`, `@BeforeClass`, `@AfterSuite`, etc.                |
| Test Configuration    | `testng.xml` allows suite and test configuration.           |
| Dependency Management | Tests can depend on other tests.                            |
| Grouping              | Tests can be grouped logically (`@Test(groups = "smoke")`). |
| Parallel Execution    | Multiple tests can run in parallel.                         |
| Reporting             | Built-in HTML & XML reports.                                |
| Data-Driven           | `@DataProvider` for parameterized testing.                  |


### **4️⃣ Example: Simple TestNG Test**

```java
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.AfterMethod;

public class CalculatorTest {

    @BeforeMethod
    public void setup() {
        System.out.println("Setup before each test");
    }

    @Test
    public void additionTest() {
        int sum = 2 + 3;
        assert sum == 5;
        System.out.println("Addition Test Passed");
    }

    @AfterMethod
    public void tearDown() {
        System.out.println("Cleanup after each test");
    }
}
```

Output when run:

```
Setup before each test
Addition Test Passed
Cleanup after each test
```

This shows how **TestNG manages the test lifecycle** with `@BeforeMethod` and `@AfterMethod`.

✅ **In short:**
TestNG is **more than just a library**, it is a **framework** for organizing, executing, and reporting Java tests efficiently.
