## 👩‍🏫 **Part 8: CI/CD Integration with Maven + Cucumber + Spring Boot**

The lab was quiet, yet electric.
Rutuja and Sanika had just completed **full-stack BDD tests** with Spring Boot and H2.
Now, it was time to see how these tests run **automatically whenever code changes**, just like in real companies.

> **Rutuja:** “Sir, so far we run tests manually. How do companies run them automatically?”
> **Sanika:** “Yes, and catch errors before production?”

I smiled.

> “This is where **CI/CD pipelines** come in — Continuous Integration and Continuous Deployment.
> Today, you’ll see your code tested **instantly on every commit**.”

### ⚙️ Scene 1: Choosing a CI Tool

I explained the options:

* Jenkins
* GitHub Actions
* GitLab CI

We chose **GitHub Actions** for simplicity.

> “It integrates directly with your repo and Maven, and it can run Cucumber tests automatically.”

### 🧩 Scene 2: Creating GitHub Actions Workflow

We created `.github/workflows/ci.yml`:

```yaml
name: Java CI with Maven and Cucumber

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
    - name: Checkout repository
      uses: actions/checkout@v3

    - name: Set up JDK 17
      uses: actions/setup-java@v3
      with:
        java-version: '17'
        distribution: 'temurin'

    - name: Build with Maven
      run: mvn clean install

    - name: Run tests
      run: mvn test
```

> **Sanika:** “Sir, this YAML file runs our tests automatically?”
> **I:** “Yes. Every push triggers Maven to build the project and execute all tests — unit and BDD.”

### ⚡ Scene 3: Push to GitHub

Rutuja committed her changes:

```bash
git add .
git commit -m "Add full-stack Cucumber tests"
git push origin main
```

Within seconds, GitHub Actions started running:

* Checkout repo ✅
* Set up JDK ✅
* Build with Maven ✅
* Run tests ✅

> **Rutuja:** “All our tests ran automatically!”
> **Sanika:** “Even parameterized BDD scenarios!”

Exactly — **automation from code commit to test report**.

### 🧩 Scene 4: Reading Test Reports

GitHub Actions displayed the results:

```
[INFO] --- maven-surefire-plugin:3.1.2:test (default-test) @ demo ---
[INFO] Tests run: 6, Failures: 0, Errors: 0, Skipped: 0, Time elapsed: 5.123 s
```

> **I:** “Notice the output. All 6 scenarios passed. You now have **full automation with CI/CD**.”

Rutuja and Sanika exchanged glances — the excitement was palpable.

> “This feels exactly like enterprise work!”

### 🧠 Scene 5: Mentor Reflection

In this session, they learned the **power of pipelines**:

1. **Push code → Build → Test → Feedback**.
2. **Immediate detection of failures** before code reaches production.
3. **Safe, repeatable, automated workflow** integrating unit tests, mocks, BDD, and database testing.
4. **Scalable testing** — multiple scenarios run with every commit.

> **Rutuja:** “Sir, this completes the picture from logic to deployment!”
> **Sanika:** “Yes, from JUnit to full CI/CD pipeline — wow!”

They weren’t just coding anymore — they were thinking **like software engineers**.

### 🪜 Next Step (Part 9 Preview)

> **“Advanced Topics: Mocking APIs, WebSockets, and Message Queues in CI/CD”**

Next, Rutuja and Sanika will **expand automation to external services**:

* Mocking REST APIs
* Simulating WebSocket connections
* Using message queues like RabbitMQ for asynchronous testing
* All integrated into CI/CD pipelines

They are now ready to see **how real microservices projects are tested and deployed**.
