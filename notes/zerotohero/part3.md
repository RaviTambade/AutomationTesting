
## 👩‍🏫 **Part 3: From Maven to First Automation Test (JUnit Awakening)**

The previous night ended with a celebration — Java, VS Code, and Maven were finally running perfectly.
The mood was confident, like two hikers who had just learned how to read a map.

And now, a new mountain stood before them — **Automation Testing with JUnit**.


### ☕ Scene 1: “Sir, what’s next after Maven?”

> **Rutuja:** “Sir, Maven install zhala… ata kay karaycha?”
> **Sanika:** “Automation testing!”

I smiled.
That spark — when students start asking *what’s next* instead of *what went wrong* — that’s growth.
I explained,

> “JUnit is your next friend. Just like you used `System.out.println` to check output manually,
> JUnit checks it **automatically** — every time you run your code.”

They nodded, curious, but slightly puzzled.
We were about to turn **programming into testing** — and that transition always changes how students think.


### 💡 Scene 2: The Maven Project Comes Alive

They created their first proper **Maven Java project**.

> **Sanika:** “Command prompt open — `mvn archetype:generate`.”
> **Rutuja:** “Oh, it’s downloading something!”

Lines of text scrolled rapidly — Maven fetching dependencies, generating folders.
It was their first exposure to the **build automation world**,
where code, dependencies, and configurations come together like clockwork.

Soon, the familiar structure appeared:

```
src
 ├── main
 │   └── java
 └── test
     └── java
```

> **Sanika:** “Sir, he test folder kasa?”
> **I:** “That’s where your automated tests live — your program’s safety net.”


### 🧩 Scene 3: The First Test

They opened the `src/test/java` folder and created a class named `CalculatorTest.java`.

Inside, we wrote the simplest possible test:

```java
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.assertEquals;

public class CalculatorTest {
    @Test
    void testAddition() {
        int result = 2 + 3;
        assertEquals(5, result);
    }
}
```

> **Rutuja:** “So this is like checking our logic?”
> **I:** “Exactly. You tell the computer — *this is what I expect.*
> If it matches, you pass. If not, you debug.”

They ran the command:

```
mvn test
```

And then came the magic:

> **BUILD SUCCESS**

The joy in their eyes said it all.
No print statements. No manual checking.
Their **code tested itself.**


### 🧠 Scene 4: “Now I Understand Automation!”

> **Sanika:** “So JUnit automatically checks output?”
> **Rutuja:** “Means no need to open console every time!”

Yes — that “click” moment had arrived.
They realized testing isn’t a separate phase — it’s a **habit woven into development**.
They learned that Maven fetches JUnit for you, builds the project, and runs tests — all in one go.

This was the shift from **writing programs** to **engineering software**.


### 🧭 Scene 5: From Curiosity to Confidence

By the end of the session:

* They had a **Maven project** structure.
* Understood **dependencies** through the `pom.xml`.
* Executed their **first JUnit test case**.
* Experienced how **automation reduces human error**.

> **Rutuja:** “Sir, next time, can we test real logic — like a Calculator class?”
> **I:** “Absolutely. Next session, we’ll build your own class and test every method.”


### 💬 Mentor Reflection

That evening reminded me — students don’t need fancy slides or frameworks first.
They need to **see their code prove itself**.
That’s when they start believing in the power of automation.

Teaching tools like JUnit and Maven isn’t about syntax —
it’s about showing how **discipline and structure** make developers reliable.

Rutuja and Sanika didn’t just learn testing that day.
They learned how to *trust their own code.*
