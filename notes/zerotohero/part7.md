## 👩‍🏫 **Part 7: Full-Stack Automation – Spring Boot, Database, and Cucumber Integration**

The lab smelled faintly of coffee and excitement.
Rutuja and Sanika had conquered unit tests, Mockito mocks, and BDD scenarios.
But today, they faced a new mountain: **real CRUD operations with database integration**.

> **Rutuja:** “Sir, now we’ll test APIs that actually touch the database?”
> **Sanika:** “Yes, and the feature file should cover all scenarios.”

I smiled.

> “Exactly. This is what real projects feel like. But don’t worry — we’ll keep it safe with **in-memory databases**.”

### ⚙️ Scene 1: Setting Up H2 Database

To avoid touching a real database, we used **H2**, an in-memory database for testing:

**`application-test.properties`**

```properties
spring.datasource.url=jdbc:h2:mem:testdb
spring.datasource.driverClassName=org.h2.Driver
spring.datasource.username=sa
spring.datasource.password=
spring.jpa.hibernate.ddl-auto=create-drop
```

> **Sanika:** “So this database exists only while tests run?”
> **I:** “Exactly. Once tests finish, it disappears — clean and fast.”


### 🧩 Scene 2: Real Repository and Entity

**`Product.java`**

```java
import jakarta.persistence.*;

@Entity
public class Product {
    @Id
    private int id;
    private String name;

    public Product() {} // Default constructor for JPA

    public Product(int id, String name) {
        this.id = id;
        this.name = name;
    }

    public int getId() { return id; }
    public String getName() { return name; }
}
```

**`ProductRepository.java`**

```java
import org.springframework.data.jpa.repository.JpaRepository;

public interface ProductRepository extends JpaRepository<Product, Integer> {
}
```

> **Rutuja:** “Now we have real database interaction…”
> **Sanika:** “…but safely in-memory!”

### ⚡ Scene 3: Updating the Service

**`ProductService.java`**

```java
import org.springframework.stereotype.Service;

@Service
public class ProductService {
    private final ProductRepository repo;

    public ProductService(ProductRepository repo) {
        this.repo = repo;
    }

    public String getProductNameById(int id) {
        return repo.findById(id).map(Product::getName).orElse("Not Found");
    }

    public Product createProduct(int id, String name) {
        return repo.save(new Product(id, name));
    }
}
```

Rutuja and Sanika noticed the difference: **methods now interact with actual JPA repository**, yet tests could remain isolated with H2.

### 🧪 Scene 4: Cucumber Feature with Parameters

**`product_crud.feature`**

```gherkin
Feature: Product CRUD operations

  Scenario Outline: Create and retrieve product
    Given a product with ID <id> and name "<name>" exists
    When I request the product name with ID <id>
    Then the response should be "<name>"

    Examples:
      | id  | name      |
      | 101 | Laptop    |
      | 102 | Smartphone |
```

> **Sanika:** “Sir, the same feature file now tests multiple products!”
> **Rutuja:** “So we can add hundreds of rows without writing extra scenarios!”

Exactly — **parameterized BDD makes tests scalable**.

### 🧩 Scene 5: Step Definitions with Repository

**`ProductStepDefinitions.java`**

```java
import io.cucumber.java.en.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
public class ProductStepDefinitions {

    @Autowired
    ProductService service;

    String response;

    @Given("a product with ID {int} and name {string} exists")
    public void createProduct(int id, String name) {
        service.createProduct(id, name);
    }

    @When("I request the product name with ID {int}")
    public void getProductName(int id) {
        response = service.getProductNameById(id);
    }

    @Then("the response should be {string}")
    public void checkResponse(String expected) {
        assertEquals(expected, response);
    }
}
```

> **Rutuja:** “Now it feels like real-world testing!”
> **Sanika:** “Yes! Database, service, API logic — all together!”

### 💻 Scene 6: Running Full-Stack Cucumber Tests

Command:

```
mvn test
```

The screen scrolled with scenarios executed.
Multiple rows from `Examples` ran one by one.

> **BUILD SUCCESS**

> **Rutuja:** “It worked! Each product name verified!”
> **Sanika:** “So scalable and automated!”

I nodded.

> “This is how enterprise teams test APIs with **BDD, database, and Spring Boot** — safely, repeatably, and human-readable.”

---

### 🧠 Scene 7: Mentor Reflection

By now, they had experienced **the full lifecycle of professional test automation**:

1. **Unit testing with JUnit** → verify logic.
2. **Mockito mocks** → isolate dependencies.
3. **Cucumber BDD** → readable tests for humans and machines.
4. **Database integration with H2** → realistic and safe environment.
5. **Parameterized feature files** → scalable, maintainable, and reusable tests.

> **Rutuja:** “Sir, now I understand why automation is called the backbone of QA!”
> **Sanika:** “It’s like building confidence in every layer.”
> **I:** “Exactly. And soon you’ll see how this maps to CI/CD pipelines in real projects.”

### 🪜 Next Step (Part 8 Preview)

> **“CI/CD + Automated BDD Pipeline”**
> Next, Rutuja and Sanika will **integrate their Maven, Spring Boot, and Cucumber tests into a CI/CD pipeline**, running automated checks whenever code is pushed — preparing them for **real-world enterprise deployment**.
