
const express = require("express");

const app = express();
const PORT = 3000;

// In-memory collection (temporary database)
let policies = [
    {
        id: 1,
        name: "Jeevan Labh",
        description: "A comprehensive insurance policy",
        maturity: "10 years"
    },
    {
        id: 2,
        name: "Jeevan Arogya",
        description: "Another insurance policy",
        maturity: "15 years"
    },
    {
        id: 3,
        name: "Jeevan Suraksha",
        description: "Yet another insurance policy",
        maturity: "20 years"
    }
];

// Middleware pipeline
app.use(express.json());

// Utility: Validate policy data
function validatePolicy(data) {
    if (!data || typeof data !== "object" || Array.isArray(data)) {
        return "Request body must be a JSON object";
    }

    const { name, description, maturity } = data;

    if (
        typeof name !== "string" || name.trim() === "" ||
        typeof description !== "string" || description.trim() === "" ||
        typeof maturity !== "string" || maturity.trim() === ""
    ) {
        return "Name, description and maturity are required";
    }

    return null;
}

// Utility: Find policy by ID
function findPolicyById(id) {
    return;
}

// Utility: Validate route ID
function parsePolicyId(id) {
    const policyId = Number(id);

    if (!Number.isInteger(policyId) || policyId <= 0) {
        return null;
    }

    return policyId;
}


// ========================================
// READ ALL POLICIES
// GET /api/policy
// ========================================

app.get("/api/policy", (req, res) => {

    res.status(200).json({
        message: "Policies retrieved successfully",
        count: policies.length,
        data: policies
    });

});


// ========================================
// READ POLICY BY ID
// GET /api/policy/:id
// ========================================

app.get("/api/policy/:id", (req, res) => {

    const policyId = parseInt(req.params.id);
    const policy =  policies.find(policy => policy.id === policyId)

    if (!policy) {
        return res.status(404).json({
            message: "Policy not found"
        });
    }

    res.status(200).json({
        message: "Policy retrieved successfully",
        data: policy
    });

});


// ========================================
// CREATE NEW POLICY
// POST /api/policy
// ========================================

app.post("/api/policy", (req, res) => {

    const newPolicy = req.body;
  

    // Add policy to collection
    policies.push(newPolicy);

    res.status(201).json({
        message: "New policy created successfully",
        data: newPolicy
    });

});


// ========================================
// UPDATE EXISTING POLICY
// PUT /api/policy/:id
// ========================================

app.put("/api/policy/:id", (req, res) => {

    const policyId = parsePolicyId(req.params.id);

    if (policyId === null) {
        return res.status(400).json({
            message: "Invalid policy ID"
        });
    }

    const existingPolicy = findPolicyById(policyId);

    if (!existingPolicy) {
        return res.status(404).json({
            message: "Policy not found"
        });
    }

    const updatedData = req.body;

    // Validate incoming data
    const validationError = validatePolicy(updatedData);

    if (validationError) {
        return res.status(400).json({
            message: validationError
        });
    }

    // Replace existing policy data
    const updatedPolicy = {
        id: policyId,
        name: updatedData.name.trim(),
        description: updatedData.description.trim(),
        maturity: updatedData.maturity.trim()
    };

    const index = policies.findIndex(p => p.id === policyId);

    policies[index] = updatedPolicy;

    res.status(200).json({
        message: "Policy updated successfully",
        data: updatedPolicy
    });

});


// ========================================
// DELETE EXISTING POLICY
// DELETE /api/policy/:id
// ========================================

app.delete("/api/policy/:id", (req, res) => {

    const policyId = parsePolicyId(req.params.id);

    if (policyId === null) {
        return res.status(400).json({
            message: "Invalid policy ID"
        });
    }

    const index = policies.findIndex(p => p.id === policyId);

    if (index === -1) {
        return res.status(404).json({
            message: "Policy not found"
        });
    }

    // Remove policy from collection
    const deletedPolicy = policies.splice(index, 1)[0];

    res.status(200).json({
        message: "Policy deleted successfully",
        data: deletedPolicy
    });

});


// ========================================
// START SERVER
// ========================================

app.listen(PORT, () => {
    console.log(`Server is running at http://localhost:${PORT}`);
});