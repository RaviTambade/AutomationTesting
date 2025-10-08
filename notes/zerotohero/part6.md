## 👩‍🏫 **Part 6: Cucumber + Spring Boot API Testing – From Unit Tests to Behavior-Driven Development**

The next morning, the lab buzzed with energy.
Rutuja and Sanika were already seated with coffees in hand, laptops open.

Yesterday they had mastered **Mockito and unit tests**.
Today, the mountain looked taller: **BDD with Cucumber**.

> **Rutuja:** “Sir, how do we write tests that even non-tech people can read?”
> **Sanika:** “Yeah, like product owners or testers!”

I smiled.

> “Exactly. That’s the magic of **Cucumber**. It allows humans to read **Given-When-Then** stories while letting computers execute them.”

### ⚙️ Scene 1: Setting Up the Project

We started with a simple **Spring Boot API**:

**`ProductController.java`**

```java
@RestController
@RequestMapping("/products")
public class ProductController {

    private final ProductService service;

    public ProductController(ProductService service) {
        this.service = service;
    }

    @GetMapping("/{id}")
    public ResponseEntity<String> getProductName(@PathVariable int id) {
        String name = service.getProductNameById(id);
        if (name.equals("Not Found")) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(name);
        }
        return ResponseEntity.ok(name);
    }
}
```

Then we added **Cucumber dependencies** in `pom.xml`:

```xml
<dependency>
    <groupId>io.cucumber</groupId>
    <artifactId>cucumber-java</artifactId>
    <version>8.13.0</version>
    <scope>test</scope>
</dependency>
<dependency>
    <groupId>io.cucumber</groupId>
    <artifactId>cucumber-spring</artifactId>
    <version>8.13.0</version>
    <scope>test</scope>
</dependency>
```

Rutuja typed carefully,
while Sanika cross-checked versions.

> “This is how automation tools plug into Maven,” I explained.

### 🧩 Scene 2: Writing the Feature File

We created a **human-readable scenario**:

**`product.feature`**

```gherkin
Feature: Get Product Name

  Scenario: Product exists
    Given the product ID 101 exists
    When I request the product name
    Then the response should be "Laptop"

  Scenario: Product does not exist
    Given the product ID 999 does not exist
    When I request the product name
    Then the response should be "Not Found"
```

> **Sanika:** “Sir, this looks like plain English!”
> **I:** “Yes! Business people can read this too. This is **BDD magic**.”

### ⚡ Scene 3: Linking Steps with Java

Under `src/test/java`, we created a **Step Definition class**:

**`ProductStepDefinitions.java`**

```java
import io.cucumber.java.en.*;
import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

public class ProductStepDefinitions {

    ProductService service;
    ProductController controller;
    String response;

    @Given("the product ID {int} exists")
    public void productExists(int id) {
        service = mock(ProductService.class);
        when(service.getProductNameById(id)).thenReturn("Laptop");
        controller = new ProductController(service);
    }

    @Given("the product ID {int} does not exist")
    public void productDoesNotExist(int id) {
        service = mock(ProductService.class);
        when(service.getProductNameById(id)).thenReturn("Not Found");
        controller = new ProductController(service);
    }

    @When("I request the product name")
    public void requestProductName() {
        // Here, we simulate API call
        response = controller.getProductName(101).getBody();
    }

    @Then("the response should be {string}")
    public void checkResponse(String expected) {
        assertEquals(expected, response);
    }
}
```

Rutuja and Sanika watched their first **BDD scenario translate into executable Java code**.

### 🧠 Scene 4: Running Cucumber with Maven

They executed:

```
mvn test
```

Lines of output scrolled:
Cucumber read the feature file, matched steps to methods, ran the tests…

> **BUILD SUCCESS**

> **Rutuja:** “Sir, it literally read the English and tested the API!”
> **Sanika:** “This is like magic… but real!”

I nodded.

> “Not magic — just disciplined automation.
> You now have unit tests, mocks, and readable BDD scenarios.
> You’re ready for professional API testing.”

### 💬 Scene 5: Mentor Reflection

The biggest lesson wasn’t syntax or tools — it was **communication**.

* **Unit tests** ensure your logic works.
* **Mockito** ensures isolation from dependencies.
* **Cucumber** ensures the story is readable and understandable to humans and machines alike.

That day, Rutuja and Sanika didn’t just learn a new framework.
They learned **how professional teams validate software collaboratively**.

> **Sanika:** “Sir, now we can tell stories and check them automatically!”
> **I:** “Exactly. This is how software engineers communicate with code *and humans* at the same time.”


### 🪜 Next Step (Part 7 Preview)

Next, they’ll dive into **full-stack automation**:

* **Spring Boot + Database + BDD integration**
* **Parameterized tests**
* **Realistic product scenarios**
* Preparing for **real-world enterprise projects**.

 