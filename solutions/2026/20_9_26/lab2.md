# 🧪 Hands-On: Unit Testing Realistic Insurance Business Rules

> **Transflower Mentor Classroom Style**
>
> **"Testing is not about checking whether code runs. Testing is about checking whether the software behaves according to the business rule."**

We will extend our previous **Node.js + Jest** example and build five realistic insurance-domain unit-testing exercises:

1. 💰 Premium Calculation
2. 👤 Policy Eligibility
3. 🏥 Claim Approval
4. 👨‍👩‍👧 Nominee Validation
5. 🔄 Policy Status Transition


# 🏗️ 1. Project Structure

Create the following project:

```text
TFLInsuranceTesting
│
├── package.json
│
├── premium.js
├── premium.spec.js
│
├── eligibility.js
├── eligibility.spec.js
│
├── claim.js
├── claim.spec.js
│
├── nominee.js
├── nominee.spec.js
│
├── policyStatus.js
└── policyStatus.spec.js
```

Install Jest:

```bash
npm install --save-dev jest
```

`package.json`:

```json
{
  "name": "tfl-insurance-testing",
  "version": "1.0.0",
  "description": "Insurance business rule unit testing using Node.js and Jest",
  "scripts": {
    "test": "jest",
    "test:watch": "jest --watch"
  },
  "devDependencies": {
    "jest": "^30.0.0"
  }
}
```


# 💰 Exercise 1 — Premium Calculation

## Business Requirement

Suppose an insurance company has the following simplified rule:

> Premium is calculated based on the policy amount and age of the customer.

For our training application:

| Customer Age | Premium Rate |
| ------------ | -----------: |
| Below 30     |           2% |
| 30–49        |           3% |
| 50 and above |           5% |

For example:

```text
Policy Amount = ₹10,00,000
Age = 25

Premium = 10,00,000 × 2%
        = ₹20,000
```


## Step 1 — Write the Business Function

Create:

```text
premium.js
```

```javascript
function calculatePremium(policyAmount, age) {

    let rate;

    if (age < 30) {
        rate = 0.02;
    }
    else if (age < 50) {
        rate = 0.03;
    }
    else {
        rate = 0.05;
    }

    return policyAmount * rate;
}

module.exports = {
    calculatePremium
};
```



# Step 2 — Think Like a Tester

We need to test the different business rules.

```text
Age < 30
   ↓
2%

Age 30–49
   ↓
3%

Age >= 50
   ↓
5%
```

So our test cases are:

| Test            |     Amount | Age | Expected |
| --------------- | ---------: | --: | -------: |
| Young customer  | ₹10,00,000 |  25 |  ₹20,000 |
| Middle age      | ₹10,00,000 |  40 |  ₹30,000 |
| Senior customer | ₹10,00,000 |  55 |  ₹50,000 |



# Step 3 — Write the Jest Specification

Create:

```text
premium.spec.js
```

```javascript
const { calculatePremium } = require("./premium");

describe("Premium Calculation", () => {

    test("Customer below 30 should pay 2% premium", () => {

        const result = calculatePremium(1000000, 25);

        expect(result).toBe(20000);
    });


    test("Customer between 30 and 49 should pay 3% premium", () => {

        const result = calculatePremium(1000000, 40);

        expect(result).toBe(30000);
    });


    test("Customer aged 50 or above should pay 5% premium", () => {

        const result = calculatePremium(1000000, 55);

        expect(result).toBe(50000);
    });

});
```

Run:

```bash
npm test
```


# 🎯 Exercise 2 — Policy Eligibility

## Business Requirement

Suppose the company has this simplified rule:

> A customer is eligible for a life insurance policy when:
>
> * Age is between 18 and 60
> * Customer must have valid income
> * Customer must not be blocked

Business rule:

```text
Age >= 18
AND
Age <= 60
AND
Income > 0
AND
Customer is not blocked
```

This is an excellent example of a **compound business rule**.



## Step 1 — Create `eligibility.js`

```javascript
function isPolicyEligible(customer) {

    if (
        customer.age >= 18 &&
        customer.age <= 60 &&
        customer.income > 0 &&
        customer.isBlocked === false
    ) {
        return true;
    }

    return false;
}

module.exports = {
    isPolicyEligible
};
```



# Step 2 — Identify Test Cases

We should not test only the happy path.

### Test 1 — Valid customer

```text
Age = 35
Income = ₹600000
Blocked = false

Expected = true
```

### Test 2 — Underage

```text
Age = 16

Expected = false
```

### Test 3 — Age above limit

```text
Age = 65

Expected = false
```

### Test 4 — No income

```text
Income = 0

Expected = false
```

### Test 5 — Blocked customer

```text
Blocked = true

Expected = false
```


# Step 3 — Write `eligibility.spec.js`

```javascript
const { isPolicyEligible } = require("./eligibility");

describe("Policy Eligibility", () => {

    test("Customer aged 35 with income should be eligible", () => {

        const customer = {
            age: 35,
            income: 600000,
            isBlocked: false
        };

        expect(isPolicyEligible(customer)).toBe(true);
    });


    test("Customer below 18 should not be eligible", () => {

        const customer = {
            age: 16,
            income: 600000,
            isBlocked: false
        };

        expect(isPolicyEligible(customer)).toBe(false);
    });


    test("Customer above 60 should not be eligible", () => {

        const customer = {
            age: 65,
            income: 600000,
            isBlocked: false
        };

        expect(isPolicyEligible(customer)).toBe(false);
    });


    test("Customer with zero income should not be eligible", () => {

        const customer = {
            age: 35,
            income: 0,
            isBlocked: false
        };

        expect(isPolicyEligible(customer)).toBe(false);
    });


    test("Blocked customer should not be eligible", () => {

        const customer = {
            age: 35,
            income: 600000,
            isBlocked: true
        };

        expect(isPolicyEligible(customer)).toBe(false);
    });

});
```



# 🏥 Exercise 3 — Claim Approval

Now let's move to an important insurance business process.

## Business Requirement

A claim can be approved when:

```text
Policy is Active
AND
Premium is Paid
AND
Claim Amount <= Sum Insured
```

For example:

```text
Policy Status = Active
Premium Paid = Yes
Sum Insured = ₹10,00,000
Claim Amount = ₹3,00,000

                  ↓

             CLAIM APPROVED
```

But:

```text
Claim Amount = ₹15,00,000

Sum Insured = ₹10,00,000

                  ↓

             CLAIM REJECTED
```



# Step 1 — Create `claim.js`

```javascript
function isClaimApproved(claim) {

    if (
        claim.policyStatus === "Active" &&
        claim.premiumPaid === true &&
        claim.claimAmount <= claim.sumInsured
    ) {
        return true;
    }

    return false;
}

module.exports = {
    isClaimApproved
};
```



# Step 2 — Write the Tests

Create:

```text
claim.spec.js
```

```javascript
const { isClaimApproved } = require("./claim");

describe("Claim Approval", () => {

    test("Active policy with paid premium and valid amount should be approved", () => {

        const claim = {
            policyStatus: "Active",
            premiumPaid: true,
            sumInsured: 1000000,
            claimAmount: 300000
        };

        expect(isClaimApproved(claim)).toBe(true);
    });


    test("Claim should be rejected when policy is inactive", () => {

        const claim = {
            policyStatus: "Inactive",
            premiumPaid: true,
            sumInsured: 1000000,
            claimAmount: 300000
        };

        expect(isClaimApproved(claim)).toBe(false);
    });


    test("Claim should be rejected when premium is not paid", () => {

        const claim = {
            policyStatus: "Active",
            premiumPaid: false,
            sumInsured: 1000000,
            claimAmount: 300000
        };

        expect(isClaimApproved(claim)).toBe(false);
    });


    test("Claim should be rejected when claim exceeds sum insured", () => {

        const claim = {
            policyStatus: "Active",
            premiumPaid: true,
            sumInsured: 1000000,
            claimAmount: 1500000
        };

        expect(isClaimApproved(claim)).toBe(false);
    });

});
```



# 👨‍👩‍👧 Exercise 4 — Nominee Validation

Nominee validation is another useful domain rule.

## Business Requirement

A policy nominee must:

```text
Have a name
AND
Have a valid relationship
AND
Have age >= 18
```

Valid relationships:

```text
Spouse
Parent
Child
Sibling
```



# Step 1 — Create `nominee.js`

```javascript
function isNomineeValid(nominee) {

    const validRelationships = [
        "Spouse",
        "Parent",
        "Child",
        "Sibling"
    ];

    if (
        nominee.name &&
        nominee.age >= 18 &&
        validRelationships.includes(nominee.relationship)
    ) {
        return true;
    }

    return false;
}

module.exports = {
    isNomineeValid
};
```



# Step 2 — Write Tests

Create:

```text
nominee.spec.js
```

```javascript
const { isNomineeValid } = require("./nominee");

describe("Nominee Validation", () => {

    test("Valid adult spouse should be accepted", () => {

        const nominee = {
            name: "Priya",
            age: 35,
            relationship: "Spouse"
        };

        expect(isNomineeValid(nominee)).toBe(true);
    });


    test("Nominee without name should be rejected", () => {

        const nominee = {
            name: "",
            age: 35,
            relationship: "Spouse"
        };

        expect(isNomineeValid(nominee)).toBe(false);
    });


    test("Nominee below 18 should be rejected", () => {

        const nominee = {
            name: "Rahul",
            age: 15,
            relationship: "Sibling"
        };

        expect(isNomineeValid(nominee)).toBe(false);
    });


    test("Invalid relationship should be rejected", () => {

        const nominee = {
            name: "Amit",
            age: 30,
            relationship: "Friend"
        };

        expect(isNomineeValid(nominee)).toBe(false);
    });

});
```


# 🔄 Exercise 5 — Policy Status Transition

This is a particularly good exercise for understanding **business-state validation**.

## Business Requirement

A policy can move between states according to defined rules.

Suppose:

```text
Pending → Active
Active  → Expired
Active  → Cancelled
```

But:

```text
Expired → Active
Cancelled → Active
Expired → Cancelled
```

are not allowed.

So we can model:

```text
                 ┌─────────┐
                 │ Pending │
                 └────┬────┘
                      │
                      ▼
                 ┌─────────┐
                 │ Active  │
                 └──┬───┬──┘
                    │   │
              ┌─────┘   └─────┐
              ▼               ▼
         ┌─────────┐     ┌───────────┐
         │ Expired │     │ Cancelled │
         └─────────┘     └───────────┘
```


# Step 1 — Create `policyStatus.js`

```javascript
const allowedTransitions = {
    Pending: ["Active"],
    Active: ["Expired", "Cancelled"],
    Expired: [],
    Cancelled: []
};

function isValidStatusTransition(currentStatus, newStatus) {

    const allowedStatuses =
        allowedTransitions[currentStatus];

    if (!allowedStatuses) {
        return false;
    }

    return allowedStatuses.includes(newStatus);
}

module.exports = {
    isValidStatusTransition
};
```


# Step 2 — Write the Tests

Create:

```text
policyStatus.spec.js
```

```javascript
const {
    isValidStatusTransition
} = require("./policyStatus");

describe("Policy Status Transition", () => {

    test("Pending policy can become Active", () => {

        expect(
            isValidStatusTransition("Pending", "Active")
        ).toBe(true);
    });


    test("Active policy can become Expired", () => {

        expect(
            isValidStatusTransition("Active", "Expired")
        ).toBe(true);
    });


    test("Active policy can become Cancelled", () => {

        expect(
            isValidStatusTransition("Active", "Cancelled")
        ).toBe(true);
    });


    test("Expired policy cannot become Active", () => {

        expect(
            isValidStatusTransition("Expired", "Active")
        ).toBe(false);
    });


    test("Cancelled policy cannot become Active", () => {

        expect(
            isValidStatusTransition("Cancelled", "Active")
        ).toBe(false);
    });


    test("Pending policy cannot directly become Expired", () => {

        expect(
            isValidStatusTransition("Pending", "Expired")
        ).toBe(false);
    });

});
```


# 🧪 Run All Tests

Our project now contains:

```text
TFLInsuranceTesting
│
├── premium.js
├── premium.spec.js
│
├── eligibility.js
├── eligibility.spec.js
│
├── claim.js
├── claim.spec.js
│
├── nominee.js
├── nominee.spec.js
│
├── policyStatus.js
├── policyStatus.spec.js
│
└── package.json
```

Run:

```bash
npm test
```

Jest discovers all files ending with:

```text
.spec.js
```

Conceptually, the execution looks like:

```text
                    Jest Test Engine
                           │
             ┌─────────────┼─────────────┐
             │             │             │
             ▼             ▼             ▼
       premium.spec   claim.spec    nominee.spec
             │             │             │
             ▼             ▼             ▼
        premium.js     claim.js     nominee.js

             ┌─────────────┴─────────────┐
             │                           │
             ▼                           ▼
     eligibility.spec          policyStatus.spec
             │                           │
             ▼                           ▼
       eligibility.js            policyStatus.js
```



# 📊 Expected Test Report

You should see something conceptually similar to:

```text
PASS  ./premium.spec.js
PASS  ./eligibility.spec.js
PASS  ./claim.spec.js
PASS  ./nominee.spec.js
PASS  ./policyStatus.spec.js

Test Suites: 5 passed, 5 total
Tests:       22 passed, 22 total
```

The exact Jest version and formatting can change the displayed output.



# 🧠 Classroom Exercise — Find the Bug

Now comes the **real learning**.

Suppose a developer accidentally changes:

```javascript
if (age < 50) {
    rate = 0.03;
}
```

instead of:

```javascript
else if (age < 50) {
    rate = 0.03;
}
```

Your tests should expose the defect.

This is where automated testing becomes valuable.

```text
Developer writes code
        ↓
Developer writes tests
        ↓
Run Jest
        ↓
       ┌───────────────┐
       │               │
       ▼               ▼
     PASS            FAIL
       │               │
       ▼               ▼
Behavior          Investigate
looks correct     business rule
```


# 🎯 Final Challenge for Students

Now give students the following requirements **without giving them the solution**.

## Challenge 1 — Premium

> If policy amount is less than ₹5,00,000, apply 2%.
> Otherwise apply 3%.

Write:

```javascript
calculatePremium()
```

and:

```text
premium.spec.js
```

## Challenge 2 — Eligibility

> Customer must be between 18 and 60 and must have annual income of at least ₹3,00,000.

Create:

```javascript
isPolicyEligible()
```

Test:

```text
18
25
60
61
17
₹2,99,999
₹3,00,000
```

**Question:** Which are boundary-value tests?


## Challenge 3 — Claim

> Claim can be approved only when:
>
> * policy is Active
> * premium is paid
> * claim amount does not exceed sum insured

Try to create **at least 6 test cases**.


## Challenge 4 — Nominee

> Nominee must have:
>
> * name
> * relationship
> * age
>
> A nominee below 18 should be rejected.

Try to identify:

```text
Happy Path
Negative Test
Boundary Test
Invalid Input Test
```

## Challenge 5 — State Transition

Create a complete transition table:

| Current   | New Status | Expected |
| --------- | ---------- | -------- |
| Pending   | Active     | ?        |
| Pending   | Cancelled  | ?        |
| Active    | Expired    | ?        |
| Active    | Cancelled  | ?        |
| Expired   | Active     | ?        |
| Cancelled | Active     | ?        |
| Expired   | Cancelled  | ?        |

Then implement the function and write the Jest specification.



# 🌱 The Bigger Picture

This exercise teaches an important software-development mindset:

```text
                  INSURANCE APPLICATION

                         Business Rule
                              │
                              ▼
                        User Story
                              │
                              ▼
                        Acceptance Rule
                              │
                              ▼
                         Test Case
                              │
                              ▼
                    Unit Test Specification
                              │
                              ▼
                        Jest Test Runner
                              │
                              ▼
                       PASS / FAIL
                              │
                              ▼
                     Developer Feedback
```

The key lesson for students is:

> **Don't write tests after you finish thinking about the business rule. Think about the business rule first, identify the expected behavior, and then express that expectation as an automated test.**

That is the transition from **"I know Jest syntax"** to **"I know how to test software."**
