
## 📄  cucumber-report.html

* When you run your **Cucumber tests**, the `plugin = {"pretty", "html:target/cucumber-report.html"}` configuration tells Cucumber to generate an **HTML report**.
* This file is usually located in your **`target` folder** in a Maven/Gradle project.
* It’s a **human-readable, interactive report** showing the results of your tests (scenarios, steps, and status).

## 🔹 **Components of the Report**

1. **Feature Overview**

   * Shows all **feature files** that were executed.
   * For each feature, you can see:

     * Name of the feature (e.g., `Product API`)
     * Description (if provided in the feature file)
     * Status summary (passed/failed/skipped)

2. **Scenarios**

   * Each feature lists all **scenarios** executed.
   * For each scenario, you can see:

     * Scenario name
     * Steps (`Given`, `When`, `Then`, `And`)
     * Step execution status:

       * ✅ Passed
       * ❌ Failed
       * ⚠ Skipped

3. **Step Details**

   * Click on a scenario to see **individual steps** and whether they passed or failed.
   * Includes **duration** of each step.
   * If a step failed, you can see:

     * **Exception message / stack trace**
     * Screenshot links (if configured for UI tests)

4. **Execution Summary**

   * Total features, scenarios, and steps executed
   * Passed, failed, and skipped counts
   * Execution time
   * Can be used to track **test health** over time

5. **Color Coding**

   * Green → Passed
   * Red → Failed
   * Yellow/Orange → Skipped or undefined steps

 

### 🔹 **Why It’s Useful**

* **For Developers:** Quickly see which scenarios broke and why.
* **For QA/Testers:** Understand test coverage and validate behavior without reading logs.
* **For Stakeholders/Business:** Provides a **readable report** of system behavior against requirements.
* **Living Documentation:** Always up-to-date because feature files are executable.

 

### ✅ Example Visual Flow in `cucumber-report.html`

```
Feature: Product API
 ├── Scenario: Get all products       ✅ Passed
 │     Given the Product API is available
 │     When I GET all products
 │     Then the response status code should be 200
 │     And the response should contain at least one product
 ├── Scenario: Create a new product  ❌ Failed
 │     Given the Product API is available
 │     When I POST a new product...
 │     Then the response status code should be 200
 │     And the response product name should be "Wireless Mouse"
```

💡 **In short:**
`cucumber-report.html` is like a **scoreboard + detailed log** for your Cucumber BDD tests — showing **what passed, what failed, and why**, in a format anyone (developer, tester, or stakeholder) can read easily.
