
## 📖 Test  Runner
The **Test Runner** in Cucumber is like the **captain of the ship** 🚢 — it decides **what tests to run, how to run them, and how to report the results**.
 
### 🔑 **Role of Test Runner**

1. **Entry Point for Cucumber Tests**

   * Without a runner, Cucumber doesn’t know where your `.feature` files or step definitions are.
   * The Test Runner tells Cucumber:

     * **features** → location of `.feature` files
     * **glue** → location of step definition code

2. **Configuration of Test Execution**

   * It configures:

     * **plugins** → reports (HTML, JSON, pretty logs, etc.)
     * **monochrome** → clean console output
     * **tags** (optional) → to filter which scenarios to run

3. **Integration with Testing Framework (JUnit/TestNG)**

   * When you extend `AbstractTestNGCucumberTests` or use `@RunWith(Cucumber.class)` in JUnit, the runner integrates Cucumber with the unit testing framework so that scenarios run as **tests**.
   * This enables parallel execution, reporting, and use of framework features.

4. **Scenario Execution**

   * Through the `@DataProvider`, the runner feeds each Cucumber scenario into TestNG so they are executed as independent tests.

5. **Reporting**

   * Generates detailed reports (HTML/JSON/XML) that summarize which features/scenarios passed or failed.

Imagine you are organizing a **drama play** in your college.

* The **script** of the drama = Your **feature files** (`.feature` in `src/test/resources/features`)
* The **actors & backstage crew** = Your **step definitions** (`glue` package → `com.example.catalog.tests`)
* The **audience program book** = The **reports** (pretty/HTML/JSON)
* But who makes sure everything runs in the right order, connects the script with the actors, and presents it nicely?

👉 That’s the **TestRunner**!


### 🎯 Role of `ProductApiTestRunner` in your code

1. **Entry Point for Cucumber Tests**

   * JUnit/TestNG itself doesn’t know where your `.feature` files and step definitions are.
   * The **runner class** (`ProductApiTestRunner`) tells Cucumber:

     * Where features live → `features = "src/test/resources/features"`
     * Where glue code (step definitions) live → `glue = {"com.example.catalog.tests"}`

2. **Configures Reporting & Formatting**

   * `plugin = {"pretty", "html:target/cucumber-report.html"}`

     * **pretty** → Console-friendly readable output
     * **html** → Generates an HTML report at `target/cucumber-report.html`

3. **Improves Console Readability**

   * `monochrome = true` removes unreadable ANSI color characters in the console logs.

4. **Integrates with TestNG (via AbstractTestNGCucumberTests)**

   * Extending `AbstractTestNGCucumberTests` makes each **scenario** behave like a **TestNG @Test method**.
   * This means you can use **TestNG features** like groups, parallel execution, listeners, etc.

5. **Scenario DataProvider (parallel execution)**

   ```java
   @Override
   @DataProvider(parallel = false)
   public Object[][] scenarios() {
       return super.scenarios();
   }
   ```

   * Each scenario is provided as a separate test case to TestNG.
   * You can switch `parallel = true` to run multiple scenarios in parallel.

 

### ✅ In short:

Your **TestRunner (`ProductApiTestRunner`)** is the **bridge** between:

* **Cucumber world (features + glue code)**
* **TestNG world (test execution, reporting, parallelism)**

It tells **what to run, how to run, and how to report**.

 