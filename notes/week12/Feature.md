

### 🔑 Feature

1. **Describe Application Behavior (Not Code)**

   * A **feature file** describes how the system should behave **in plain English** (using Gherkin language).
   * It focuses on **what** the application should do, not **how** it’s implemented.

   Example:

   ```gherkin
   Feature: Product Management
     Scenario: Get all products
       Given the product catalog is available
       When I request all products
       Then I should receive a list of products
   ```

2. **Act as a Shared Contract**

   * Acts like a **contract** between:

     * **Business/Stakeholders** (who understand the requirements)
     * **Developers & Testers** (who implement and verify it)
   * Everyone can read and agree on these scenarios.

3. **Drive Development (BDD)**

   * Features are the **starting point of Behavior-Driven Development (BDD)**.
   * Developers implement **step definitions** to automate the scenarios described in the feature.

4. **Organize Tests**

   * Each `.feature` file groups related scenarios together.
   * This makes tests readable, maintainable, and directly traceable to requirements.

5. **Executable Documentation**

   * Features double as **living documentation**.
   * They always stay up to date because they are **executed as tests**.
 

✅ **In simple words:**
A **feature** in Cucumber is like the **story book** 📖 of your application.

* It tells **what the system should do** in user-friendly language.
* Cucumber then turns those stories into **executable tests** via step definitions.

 
 ## 📄 Feature File Breakdown

```gherkin
Feature: Product API
```

* **Feature**: A high-level description of what you are testing.
* Here, we are focusing on the **Product API** (like a module or functionality of your application).
* This tells us: *“All the scenarios below will be related to Product API behavior.”*

 

### 🟢 Scenario 1: Get all products

```gherkin
Scenario: Get all products
  Given the Product API is available
  When I GET all products
  Then the response status code should be 200
  And the response should contain at least one product
```

* **Scenario**: A concrete example of how the Product API should behave.
* **Given**: Precondition (setup) → “The Product API is available” means the service must be running.
* **When**: Action → “I GET all products” means we are sending a **GET request** to `/products`.
* **Then**: Expected outcome → “status code should be 200” means success.
* **And**: Additional validation → “response should contain at least one product” ensures the data is not empty.

👉 This scenario is basically: *“If I hit the API to fetch all products, it should return success with some data.”*

 

### 🟢 Scenario 2: Create a new product

```gherkin
Scenario: Create a new product
  Given the Product API is available
  When I POST a new product with id 4, name "Wireless Mouse", price 1500
  Then the response status code should be 200
  And the response product name should be "Wireless Mouse"
```

* **Given**: The Product API must be running.
* **When**: Action → “I POST a new product” means we send a **POST request** with JSON body like:

  ```json
  {
    "id": 4,
    "name": "Wireless Mouse",
    "price": 1500
  }
  ```
* **Then**: Expect HTTP **200 OK** as response.
* **And**: Validate that the product returned in response has the correct **name = "Wireless Mouse"**.

👉 This scenario says: *“When I create a new product, the API should respond successfully and return that product back correctly.”*

 

## 🔑 Why this Feature File is Important

* It is **not code**, but **plain English requirements**.
* Business stakeholders can **read it** and confirm requirements.
* Developers/testers can **automate it** by writing step definitions.
* It becomes **living documentation**: always up-to-date because it runs as a test.

 

✅ **In simple terms:**
This **feature file** is a **blueprint of Product API behavior** written in human-readable language.

* *Feature* → The big module under test (Product API)
* *Scenario* → A real-world example/test case
* *Given/When/Then* → Steps that define precondition, action, and expected result

 