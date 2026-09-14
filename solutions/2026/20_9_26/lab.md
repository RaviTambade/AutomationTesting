# 🧪 Unit Testing a Policy Using Node.js + Jest

> **Learning objective:**
> Learn how to convert a simple **insurance policy business rule** into an automated **unit test** using **Node.js + Jest**.



## 1. The Business Requirement

Suppose our insurance application has the following policy rule:

> **A policy is eligible for renewal only when its status is `Active`.**

So:

| Policy Status | Renewal Eligible? |
| ------------- | ----------------- |
| Active        | ✅ Yes             |
| Inactive      | ❌ No              |
| Expired       | ❌ No              |
| Cancelled     | ❌ No              |

As developers, we need to convert this business rule into executable code.



# 2. Create the Node.js Project

Create a folder:

```text
TFLInsuranceTesting
```

Open the terminal inside this folder.

Initialize Node.js:

```bash
npm init -y
```

Install Jest:

```bash
npm install --save-dev jest
```

Our project will look like:

```text
TFLInsuranceTesting
│
├── policy.js
├── policy.spec.js
├── package.json
└── node_modules/
```


# 3. Create the Policy Module

Create:

```text
policy.js
```

Add the following code:

```javascript
function isEligibleForRenewal(policy) {

    if (policy.status === "Active") {
        return true;
    }

    return false;
}

module.exports = {
    isEligibleForRenewal
};
```

### What does this function do?

Input:

```javascript
{
    policyNumber: "POL1001",
    status: "Active"
}
```

Output:

```text
true
```

For:

```javascript
{
    policyNumber: "POL1002",
    status: "Expired"
}
```

Output:

```text
false
```


# 4. What Should We Test?

Now think like a tester. Our business rule says:

```text
Active       → true
Inactive     → false
Expired      → false
Cancelled    → false
```

Therefore, we need test cases.

### Test Case 1

```text
Given:
Policy status = Active

Expected:
Renewal eligible = true
```

### Test Case 2

```text
Given:
Policy status = Expired

Expected:
Renewal eligible = false
```

### Test Case 3

```text
Given:
Policy status = Cancelled

Expected:
Renewal eligible = false
```

# 5. Create the Jest Specification

Create:

```text
policy.spec.js
```

Add:

```javascript
const { isEligibleForRenewal } = require("./policy");

test("Active policy should be eligible for renewal", () => {

    const policy = {
        policyNumber: "POL1001",
        status: "Active"
    };

    const result = isEligibleForRenewal(policy);

    expect(result).toBe(true);
});
```

This is our first unit test.



# 6. Understand the Test

Look at this:

```javascript
test("Active policy should be eligible for renewal", () => {
```

`test()` tells Jest:

> "I want to execute a test."


Then:

```javascript
const policy = {
    policyNumber: "POL1001",
    status: "Active"
};
```

This is the **test input**.



Then:

```javascript
const result = isEligibleForRenewal(policy);
```

We execute the **unit under test**.



Finally:

```javascript
expect(result).toBe(true);
```

This is the **verification**.

In simple terms:

```text
             UNIT TEST
                 │
                 ▼
       ┌───────────────────┐
       │      INPUT        │
       │                   │
       │ status = Active   │
       └─────────┬─────────┘
                 │
                 ▼
       ┌───────────────────┐
       │  POLICY FUNCTION  │
       │                   │
       │ isEligibleFor     │
       │ Renewal()         │
       └─────────┬─────────┘
                 │
                 ▼
       ┌───────────────────┐
       │      RESULT       │
       │                   │
       │       true        │
       └─────────┬─────────┘
                 │
                 ▼
       ┌───────────────────┐
       │      EXPECT       │
       │                   │
       │ expect(result)    │
       │    .toBe(true)    │
       └───────────────────┘
```



# 7. Configure Jest

Open:

```text
package.json
```

Change the `scripts` section:

```json
{
  "name": "tfl-insurance-testing",
  "version": "1.0.0",
  "description": "Unit testing insurance policy using Node.js and Jest",
  "main": "policy.js",
  "scripts": {
    "test": "jest"
  },
  "devDependencies": {
    "jest": "^30.0.0"
  }
}
```

The important part is:

```json
"scripts": {
    "test": "jest"
}
```


# 8. Execute the Test

Run:

```bash
npm test
```

Jest will automatically find:

```text
policy.spec.js
```

You should see output similar to:

```text
PASS  ./policy.spec.js

✓ Active policy should be eligible for renewal

Test Suites: 1 passed, 1 total
Tests:       1 passed, 1 total
```

🎉 Our first unit test is successful.


# 9. Add More Policy Tests

Now let's make our specification more complete.

Update `policy.spec.js`:

```javascript
const { isEligibleForRenewal } = require("./policy");

test("Active policy should be eligible for renewal", () => {

    const policy = {
        policyNumber: "POL1001",
        status: "Active"
    };

    const result = isEligibleForRenewal(policy);

    expect(result).toBe(true);
});


test("Expired policy should not be eligible for renewal", () => {

    const policy = {
        policyNumber: "POL1002",
        status: "Expired"
    };

    const result = isEligibleForRenewal(policy);

    expect(result).toBe(false);
});


test("Cancelled policy should not be eligible for renewal", () => {

    const policy = {
        policyNumber: "POL1003",
        status: "Cancelled"
    };

    const result = isEligibleForRenewal(policy);

    expect(result).toBe(false);
});


test("Inactive policy should not be eligible for renewal", () => {

    const policy = {
        policyNumber: "POL1004",
        status: "Inactive"
    };

    const result = isEligibleForRenewal(policy);

    expect(result).toBe(false);
});
```

Run:

```bash
npm test
```

Expected:

```text
PASS  ./policy.spec.js

✓ Active policy should be eligible for renewal
✓ Expired policy should not be eligible for renewal
✓ Cancelled policy should not be eligible for renewal
✓ Inactive policy should not be eligible for renewal

Test Suites: 1 passed, 1 total
Tests:       4 passed, 4 total
```


# 10. Understand the Testing Architecture

The complete flow is:

```text
             Business Requirement
                     │
                     ▼
       ┌──────────────────────────┐
       │ "Active policy can be    │
       │  renewed"                │
       └────────────┬─────────────┘
                    │
                    ▼
              Test Case
                    │
                    ▼
          policy.spec.js
                    │
                    ▼
              Jest Engine
                    │
                    ▼
             policy.js
                    │
                    ▼
              Function
                    │
                    ▼
                Result
                    │
                    ▼
                expect()
                    │
             ┌──────┴──────┐
             │             │
             ▼             ▼
           PASS           FAIL
```


# 11. Test vs Test Case vs Unit Test vs Testing Framework

This example helps differentiate the terminology.

### Test

A **test** verifies a particular behavior.

```text
Active policy should be eligible for renewal
```

### Test Case

A test case describes:

```text
Input:
Policy status = Active

Expected:
true
```

### Unit Test

The test verifies a **small unit of code**:

```javascript
isEligibleForRenewal()
```

### Testing Framework

Jest provides the infrastructure for executing our tests:

```text
Jest
 ├── test()
 ├── expect()
 ├── matchers
 ├── test runner
 └── test report
```


# 12. A Better Jest Style — `describe()`

As the application grows, we can organize related tests.

```javascript
const { isEligibleForRenewal } = require("./policy");

describe("Policy Renewal", () => {

    test("Active policy should be eligible for renewal", () => {

        const policy = {
            policyNumber: "POL1001",
            status: "Active"
        };

        expect(isEligibleForRenewal(policy))
            .toBe(true);
    });


    test("Expired policy should not be eligible for renewal", () => {

        const policy = {
            policyNumber: "POL1002",
            status: "Expired"
        };

        expect(isEligibleForRenewal(policy))
            .toBe(false);
    });


    test("Cancelled policy should not be eligible for renewal", () => {

        const policy = {
            policyNumber: "POL1003",
            status: "Cancelled"
        };

        expect(isEligibleForRenewal(policy))
            .toBe(false);
    });

});
```

Now Jest's report becomes conceptually:

```text
Policy Renewal

    ✓ Active policy should be eligible for renewal
    ✓ Expired policy should not be eligible for renewal
    ✓ Cancelled policy should not be eligible for renewal
```


# 13. The Important Testing Formula

As a mentor, I would ask students to remember this simple formula:

```text
              UNIT TEST

        Arrange → Act → Assert
```

### Arrange

Prepare the input:

```javascript
const policy = {
    policyNumber: "POL1001",
    status: "Active"
};
```

### Act

Execute the function:

```javascript
const result = isEligibleForRenewal(policy);
```

### Assert

Verify the result:

```javascript
expect(result).toBe(true);
```

So:

```text
┌──────────────┐
│   ARRANGE    │
│              │
│ Prepare data │
└──────┬───────┘
       │
       ▼
┌──────────────┐
│     ACT      │
│              │
│ Call method  │
└──────┬───────┘
       │
       ▼
┌──────────────┐
│    ASSERT    │
│              │
│ Verify result│
└──────────────┘
```

> **Mentor takeaway:**
> A good unit test is not simply "some code that calls a function."
> It expresses a **business expectation** in an executable form.

For our insurance application:

```text
Business Rule
      ↓
Test Case
      ↓
Jest Specification
      ↓
Execute
      ↓
PASS / FAIL
```