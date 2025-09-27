 
# 🎯 Why Assertions are Used in Unit Testing

Think of **assertions** as the **referees** in a match.
Your code (the player) performs some action, and the referee (assertion) checks: *“Did the result match what was expected?”*

If yes → test passes ✅
If no → test fails ❌

### 🔑 Core Purposes of Assertions

1. **Verify correctness of code**

   * Assertions compare *expected* vs *actual* output.
   * Example:

     ```java
     assertEquals(42, calculator.add(40, 2));
     ```

     Ensures your addition logic is correct.

 2. **Detect bugs early**

   * If an assertion fails, it signals a **logic error** immediately.
   * Saves time by catching defects during development rather than in production.
 

3. **Automate validation**

   * Instead of manually checking outputs (printing values, debugging), assertions automate verification.
   * Example: Instead of `System.out.println(result);`, use

     ```java
     assertTrue(result > 0);
     ```

4. **Ensure code reliability after changes (Regression testing)**

   * When code is modified, assertions confirm that old functionality still works.
   * Example: If you refactor a sorting method, `assertArrayEquals` ensures it still sorts correctly.

5. **Communicate intent clearly**

   * Assertions act as **documentation** of expected behavior.
   * Future developers (or your students) can see: *“Oh, this method should always return a non-null value.”*

6. **Increase confidence in refactoring & CI/CD**

   * With assertions in place, you can safely change code.
   * If something breaks, tests fail immediately during build pipelines.

✅ **In short**:
Assertions make unit tests useful. Without assertions, a test is just running code — with assertions, a test verifies correctness, documents expectations, and prevents regressions.


## ✅ Commonly Used JUnit Assertions

### 1. **Equality and Inequality**

* `assertEquals(expected, actual)` → checks if two values are equal
* `assertNotEquals(unexpected, actual)` → checks if two values are not equal

👉 Overloaded versions exist for `int`, `long`, `double`, `float`, `String`, `Object`, etc.
For floating-point numbers, you can provide a **delta**:

```java
assertEquals(3.14, myCalculator.pi(), 0.01);
```

### 2. **Boolean Checks**

* `assertTrue(condition)` → checks if condition is `true`
* `assertFalse(condition)` → checks if condition is `false`

### 3. **Null Checks**

* `assertNull(object)` → verifies object is `null`
* `assertNotNull(object)` → verifies object is not `null`

### 4. **Object Identity**

* `assertSame(expected, actual)` → verifies two references point to the **same object**
* `assertNotSame(unexpected, actual)` → verifies two references point to **different objects**

### 5. **Exception Testing**

* `assertThrows(Exception.class, () -> { ... })` → checks if code block throws an exception
* `assertDoesNotThrow(() -> { ... })` → checks that code block does **not** throw exception

```java
assertThrows(IllegalArgumentException.class, () -> myService.process(null));
```

### 6. **Iterable / Array Comparisons**

* `assertArrayEquals(expectedArray, actualArray)` → compares two arrays element by element
* `assertIterableEquals(expectedIterable, actualIterable)` → compares two iterables element by element

### 7. **Grouped Assertions**

* `assertAll("group name", () -> assertEquals(...), () -> assertTrue(...))`
  → run multiple assertions together and report all failures at once.

```java
assertAll("user details",
    () -> assertEquals("Ravi", user.getName()),
    () -> assertTrue(user.isActive())
);
```

### 8. **Timeout Assertions**

* `assertTimeout(Duration.ofMillis(100), () -> myMethod())` → ensures code finishes within time
* `assertTimeoutPreemptively(Duration.ofMillis(100), () -> myMethod())` → aborts test if exceeds time

### 9. **Fail on Purpose**

* `fail("Test should not reach here!")` → explicitly fails a test

## 📌 Example: Using Multiple Assertions

```java
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

class CalculatorTest {

    @Test
    void testAddition() {
        Calculator calc = new Calculator();
        int result = calc.add(2, 3);

        assertEquals(5, result);
        assertNotEquals(6, result);
        assertTrue(result > 0);
        assertNotNull(result);
    }

    @Test
    void testDivisionByZero() {
        Calculator calc = new Calculator();

        assertThrows(ArithmeticException.class, () -> calc.divide(10, 0));
    }
}
```
 