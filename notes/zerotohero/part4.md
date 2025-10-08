
## 👩‍🏫 **Part 4: JUnit + Calculator Hands-On – Testing Our Own Logic**

The lab was quiet that morning.
The sound of fans, the click of keyboards, and two focused faces—**Rutuja** and **Sanika**—ready to level up.

Yesterday’s “BUILD SUCCESS” from Maven still echoed in their minds.
They had tasted automation. Now they wanted more.

### ⚙️ Scene 1: “Let’s Build Something Real”

> **Rutuja:** “Sir, kal aapan test madhe manually 2+3 kelay hota. Aaj actual method lihaycha ka?”
> **Sanika:** “Ho sir, real calculator class banvaycha!”

I smiled.

> “Yes. Because automation is meaningful only when it tests *your* logic.”

So we created a new Java class under `src/main/java`:

**📁 Calculator.java**

```java
public class Calculator {

    public int add(int a, int b) {
        return a + b;
    }

    public int subtract(int a, int b) {
        return a - b;
    }

    public int multiply(int a, int b) {
        return a * b;
    }

    public int divide(int a, int b) {
        if (b == 0)
            throw new IllegalArgumentException("Cannot divide by zero");
        return a / b;
    }
}
```

Rutuja typed carefully,
while Sanika double-checked each bracket.
No IDE shortcuts. No code generation. Just pure logic.

### 🧪 Scene 2: “Now Let’s Test It”

Under `src/test/java`, they created:

**📁 CalculatorTest.java**

```java
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class CalculatorTest {

    Calculator calc = new Calculator();

    @Test
    void testAddition() {
        assertEquals(8, calc.add(5, 3));
    }

    @Test
    void testSubtraction() {
        assertEquals(2, calc.subtract(5, 3));
    }

    @Test
    void testMultiplication() {
        assertEquals(15, calc.multiply(5, 3));
    }

    @Test
    void testDivision() {
        assertEquals(2, calc.divide(10, 5));
    }

    @Test
    void testDivideByZero() {
        assertThrows(IllegalArgumentException.class, () -> calc.divide(10, 0));
    }
}
```

> **Sanika:** “Sir, what’s this `assertThrows`?”
> **I:** “That’s how we *expect* an error. JUnit doesn’t panic—it checks if your exception is correct.”

They both nodded, smiling.
This was **structured testing** — no print statements, no guessing.

### 💻 Scene 3: The Command

They switched to the terminal:

```
mvn test
```

The screen flickered. Maven ran.
Lines appeared.
Tests executed.

> **BUILD SUCCESS**

A cheer broke the silence.

> **Rutuja:** “Sir! Sagle test pass zhale!”
> **Sanika:** “Means our logic is perfect!”

I corrected gently,

> “Your logic is *verified* — and that’s even better than perfect.”


### 🧠 Scene 4: Understanding Test-Driven Thinking

I explained how this small exercise carries a big philosophy:

* Code and test should **grow together**.
* Tests are **guardians of logic**.
* Automation makes your work **predictable and repeatable**.

> **Sanika:** “So in real companies, they write test first?”
> **I:** “Yes, that’s called Test-Driven Development.
> Think logic first, then prove it with a test.”

### 💬 Scene 5: Mentor Reflection

That day, the shift was visible.
The nervousness of setup had turned into calm focus.
They weren’t *trying things* anymore — they were *designing and validating*.

They saw how JUnit enforces discipline —
that every method must justify its correctness through a test.

> **Rutuja:** “Sir, it feels like coding with safety net.”
> **I:** “Exactly. You can climb higher because you know your foundation is safe.”

### 🪜 Next Step (Part 5 Preview)

The next session will be a milestone —

> **“Maven + JUnit + Mock Objects = Unit Testing Real-World Logic”**

They’ll learn how to **mock** dependencies,
test without databases,
and prepare for **Spring Boot Controller Testing** with Cucumber next.

