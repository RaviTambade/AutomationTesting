# Parallel Test Execution

## **1️⃣ What is Parallel Test Execution?**

Parallel execution in TestNG allows **multiple tests or methods to run simultaneously**, instead of one after the other. This reduces overall test execution time, which is especially useful when:

* You have many tests.
* Tests involve **slow operations** (like Selenium WebDriver, API calls, or database operations).
* You want **faster feedback** in CI/CD pipelines.

 
## **2️⃣ Parallel Execution Levels in TestNG**

TestNG supports parallel execution at different levels:

| Level       | Description                                             |
| ----------- | ------------------------------------------------------- |
| `tests`     | Runs multiple `<test>` tags in parallel.                |
| `classes`   | Runs multiple **classes** in parallel.                  |
| `methods`   | Runs all **test methods** in parallel.                  |
| `instances` | Runs different instances of the same class in parallel. |

**Thread count** controls how many threads TestNG can use simultaneously.

## **3️⃣ Example: Parallel Methods Execution**

**Goal:** Run all test methods of multiple classes at the same time.

### **CalculatorTest.java**

```java
package tests;

import org.testng.annotations.Test;

public class CalculatorTest {

    @Test
    public void additionTest() throws InterruptedException {
        Thread.sleep(2000);
        System.out.println("Addition Test - Thread: " + Thread.currentThread().getId());
    }

    @Test
    public void subtractionTest() throws InterruptedException {
        Thread.sleep(2000);
        System.out.println("Subtraction Test - Thread: " + Thread.currentThread().getId());
    }
}
```

### **AdvancedCalculatorTest.java**

```java
package tests;

import org.testng.annotations.Test;

public class AdvancedCalculatorTest {

    @Test
    public void squareRootTest() throws InterruptedException {
        Thread.sleep(2000);
        System.out.println("SquareRoot Test - Thread: " + Thread.currentThread().getId());
    }

    @Test
    public void powerTest() throws InterruptedException {
        Thread.sleep(2000);
        System.out.println("Power Test - Thread: " + Thread.currentThread().getId());
    }
}
```

### **testng.xml**

```xml
<!DOCTYPE suite SYSTEM "https://testng.org/testng-1.0.dtd">
<suite name="ParallelMethodsSuite" parallel="methods" thread-count="4">

    <test name="AllTests">
        <classes>
            <class name="tests.CalculatorTest"/>
            <class name="tests.AdvancedCalculatorTest"/>
        </classes>
    </test>

</suite>
```

**Explanation:**

* `parallel="methods"` → All **methods** run in parallel.
* `thread-count="4"` → Up to 4 threads can run simultaneously.
* Each test method runs in its own thread.

 
## **4️⃣ Expected Output**

```
Addition Test - Thread: 12
Subtraction Test - Thread: 13
SquareRoot Test - Thread: 14
Power Test - Thread: 15
```

✅ Notice all 4 tests ran **simultaneously**, drastically reducing execution time.
 

## **5️⃣ Key Points**

1. **Thread Safety:**

   * Avoid shared objects unless thread-safe.
   * Example: Selenium WebDriver instances should use `ThreadLocal<WebDriver>`.

2. **DataProvider in Parallel:**

   ```java
   @DataProvider(name="dp", parallel=true)
   public Object[][] dataProviderMethod() { ... }
   ```

3. **Choosing Parallel Level:**

   * `methods` → max concurrency.
   * `classes` → classes run simultaneously but methods inside a class run sequentially.
   * `tests` → multiple `<test>` tags run simultaneously.

Parallel Test Execution is **critical for speeding up automation suites** in real-world projects, especially in CI/CD pipelines.

## **1️⃣ Parallel Test Execution Types in TestNG**

TestNG allows **parallel execution** at different levels, controlled in `testng.xml`:

| Level       | Description                                             |
| ----------- | ------------------------------------------------------- |
| `tests`     | Runs multiple `<test>` tags in parallel.                |
| `classes`   | Runs all test methods of multiple classes in parallel.  |
| `methods`   | Runs all test methods in a single class in parallel.    |
| `instances` | Runs different instances of the same class in parallel. |


## **2️⃣ How to Configure Parallel Execution in `testng.xml`**

Here’s an example:

```xml
<!DOCTYPE suite SYSTEM "https://testng.org/testng-1.0.dtd">
<suite name="MyTestSuite" parallel="methods" thread-count="3">

    <test name="CalculatorTests">
        <classes>
            <class name="tests.CalculatorTest"/>
            <class name="tests.AdvancedCalculatorTest"/>
        </classes>
    </test>

</suite>
```

**Explanation:**

* `parallel="methods"` → all test methods run in parallel.
* `thread-count="3"` → maximum of 3 threads run simultaneously.
* Each test class (`CalculatorTest`, `AdvancedCalculatorTest`) methods will execute concurrently.

 

## **3️⃣ Example with Parallel Methods**

```java
package tests;

import org.testng.annotations.Test;

public class CalculatorTest {

    @Test
    public void additionTest() throws InterruptedException {
        Thread.sleep(2000); // Simulate long running test
        System.out.println("Addition Test: " + Thread.currentThread().getId());
    }

    @Test
    public void subtractionTest() throws InterruptedException {
        Thread.sleep(2000);
        System.out.println("Subtraction Test: " + Thread.currentThread().getId());
    }

    @Test
    public void multiplicationTest() throws InterruptedException {
        Thread.sleep(2000);
        System.out.println("Multiplication Test: " + Thread.currentThread().getId());
    }
}
```

**Output (Thread IDs show parallel execution):**

```
Addition Test: 12
Subtraction Test: 13
Multiplication Test: 14
```

* All three tests ran **at the same time** in different threads.

 

## **4️⃣ Important Points When Running Parallel Tests**

1. **Thread Safety:**

   * Avoid sharing mutable objects between tests.
   * Use `ThreadLocal` for WebDriver instances in Selenium.

2. **Parallel + DataProvider:**

   * You can also run **data-driven tests** in parallel:

     ```xml
     <suite name="Suite" parallel="tests" thread-count="2">
     ```

     And use `@DataProvider(parallel = true)`.

3. **Combining Levels:**

   * You can run `<tests>` in parallel and `<methods>` inside each test for maximum concurrency.

4. **Use Thread-safe Tools:**

   * WebDriver, databases, or file operations must handle parallel access.

 

✅ **In short:**

* Set `parallel` attribute in `testng.xml` (`methods`, `classes`, or `tests`).
* Use `thread-count` to control the number of simultaneous threads.
* Make tests **thread-safe** to avoid interference.

 
