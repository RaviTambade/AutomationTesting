
## 👩‍🏫 **Part 5: Mocking Dependencies – Testing Real-World Logic with Mockito**

The monsoon drizzle was back that evening.
Inside the lab, two familiar faces — **Rutuja** and **Sanika** — opened their laptops with quiet excitement.

Last time, they had mastered JUnit and watched their calculator code test itself.
But today’s lesson would take them closer to *industry-level automation*:
testing **real logic without real dependencies**.

### ☕ Scene 1: “Sir, real projects have databases… how do we test those?”

> **Rutuja:** “Sir, in actual project we have service-class logic and database calls… do we need a database for every test?”
> **Sanika:** “Otherwise test fail hoil na?”

I smiled.

> “Great question! Real-world testing isn’t about connecting everything.
> It’s about **isolating** logic and simulating behaviour.
> That’s where **Mockito** comes in.”

They looked curious — half-testing engineers, half-detectives now.

### 🧩 Scene 2: Building a Mini Service Layer

I gave them a realistic mini-project:

**`ProductService.java`**

```java
public class ProductService {

    private ProductRepository repo;

    public ProductService(ProductRepository repo) {
        this.repo = repo;
    }

    public String getProductNameById(int id) {
        Product p = repo.findById(id);
        if (p == null)
            return "Not Found";
        return p.getName();
    }
}
```

**`ProductRepository.java`**

```java
public interface ProductRepository {
    Product findById(int id);
}
```

**`Product.java`**

```java
public class Product {
    private int id;
    private String name;

    public Product(int id, String name) {
        this.id = id;
        this.name = name;
    }
    public int getId() { return id; }
    public String getName() { return name; }
}
```

> **Sanika:** “So ProductService depends on ProductRepository.”
> **I:** “Exactly — and we’ll test ProductService *without touching a real database.*”

### 🧪 Scene 3: Introducing Mockito

We added a Maven dependency to `pom.xml`:

```xml
<dependency>
    <groupId>org.mockito</groupId>
    <artifactId>mockito-core</artifactId>
    <version>5.14.0</version>
    <scope>test</scope>
</dependency>
```

Then came the test class.

**`ProductServiceTest.java`**

```java
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

public class ProductServiceTest {

    @Test
    void testGetProductNameById() {
        // 1. Create mock repository
        ProductRepository mockRepo = mock(ProductRepository.class);

        // 2. Define behaviour
        when(mockRepo.findById(101)).thenReturn(new Product(101, "Laptop"));

        // 3. Inject mock into service
        ProductService service = new ProductService(mockRepo);

        // 4. Verify logic
        assertEquals("Laptop", service.getProductNameById(101));
        assertEquals("Not Found", service.getProductNameById(999));

        // 5. Verify interaction
        verify(mockRepo).findById(101);
    }
}
```

### ⚡ Scene 4: The “Aha!” Moment

They ran:

```
mvn test
```

And there it was — **BUILD SUCCESS** again.

> **Rutuja:** “Sir, test passed… without database!”
> **Sanika:** “So Mockito acts like fake repository?”

Exactly.
I explained:

> “Mockito doesn’t connect to real data.
> It pretends — like an actor who plays the role of a database.
> You tell it what to return, and it behaves accordingly.
> This keeps tests *fast, focused, and independent.*”

Their expressions changed from curiosity to clarity.
They were starting to think like **engineers** — understanding separation of concerns.

### 🧠 Scene 5: Lessons Beyond Code

By the end of that session, they had learned:

* How to **mock dependencies** using Mockito.
* How to **test logic in isolation**.
* How to **verify method calls** to ensure correct flow.
* Why real companies prefer **unit tests over integration tests** for frequent validation.

> **Rutuja:** “Sir, real test cases are like mini-stories!”
> **I:** “Exactly. Each test should narrate what logic is being checked and why.”


### 💬 Mentor Reflection

That evening felt special.
Two students who once struggled to install Java were now talking about *mocking and dependency injection*.
This wasn’t just skill growth — it was *mindset transformation.*

They had learned to **question what needs to be real** and what can be **simulated**.
They saw how testing mirrors life — you can practice in safe conditions before facing the real world.

### 🪜 Next Step (Part 6 Preview)

> **“Cucumber + Spring Boot API Testing – From Unit Tests to Behavior-Driven Development”**

Next time, Rutuja and Sanika will connect everything:
Mocked services, real controllers, and human-readable **Gherkin feature files**.
