## 🔑 Step Definitions in Cucumber

Step Definitions (often called **stepdefs**) are the **glue between your plain English feature files and actual test code**.

* **Feature file**: “What to test” (plain English / Gherkin)
* **Step definitions**: “How to test it” (actual Java, Python, or JS code)


### 🔹 Example

#### Feature File

```gherkin
Feature: Product API

  Scenario: Get all products
    Given the Product API is available
    When I GET all products
    Then the response status code should be 200
    And the response should contain at least one product
```

#### Step Definitions (Java + RestAssured)

```java
package com.example.catalog.tests;

import io.cucumber.java.en.*;
import io.restassured.RestAssured;
import io.restassured.response.Response;
import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.*;

public class ProductStepDefs {

    private Response response;

    @Given("the Product API is available")
    public void productApiIsAvailable() {
        RestAssured.baseURI = "http://localhost:9090";
    }

    @When("I GET all products")
    public void iGetAllProducts() {
        response = RestAssured.get("/products");
    }

    @Then("the response status code should be {int}")
    public void responseStatusCodeShouldBe(int statusCode) {
        assertThat(response.getStatusCode(), equalTo(statusCode));
    }

    @Then("the response should contain at least one product")
    public void responseShouldContainAtLeastOneProduct() {
        assertThat(response.jsonPath().getList("$"), is(not(empty())));
    }
}
```


### 🔹 Key Points

1. **Annotations** link steps to code:

   * `@Given`, `@When`, `@Then`, `@And`
   * The text inside the annotation **matches exactly** the text in the feature file (or can use regex/parameters).

2. **Code Execution**

   * Each step executes the code inside its method.
   * It can call APIs, query databases, validate responses, or perform UI actions.

3. **Parameters**

   * You can pass values from feature files into step definitions:

   ```gherkin
   When I POST a new product with id 4, name "Wireless Mouse", price 1500
   ```

   ```java
   @When("I POST a new product with id {int}, name {string}, price {int}")
   public void createProduct(int id, String name, int price) { ... }
   ```

4. **Reusability**

   * Multiple scenarios can reuse the same step definitions.

 
### ✅ In simple words:

Step Definitions are the **bridge between human-readable requirements (features) and executable tests (code)**.

* Features = “What to do”
* Step Definitions = “How to do it”
