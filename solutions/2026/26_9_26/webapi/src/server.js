
//Node js Server Side PRogramming

//Framework: Express js
//Language: JavaScript
//Logic: REST API

//operations: CRUD operations


//POST: post, GET: get, PUT: update, DELETE: delete




const express = require('express');
const app = express(); //webapp object
const PORT = 3000; //define port number

app.get("/api/policy", (req, res) => {
    let policies=[
        { id: 1, name: "Jeevan Labh", description: "A comprehensive insurance policy", maturity: "10 years" },
        { id: 2, name: "Jeevan Arogya", description: "Another insurance policy", maturity: "15 years" },
        { id: 3, name: "Jeevan Suraksha", description: "Yet another insurance policy", maturity: "20 years" }
    ];
    res.json(policies);
});

app.get("/api/policy/:id", (req, res) => {

    const policyId = parseInt(req.params.id);

    let policies=[
        { id: 1, name: "Jeevan Labh", description: "A comprehensive insurance policy", maturity: "10 years" },
        { id: 2, name: "Jeevan Arogya", description: "Another insurance policy", maturity: "15 years" },
        { id: 3, name: "Jeevan Suraksha", description: "Yet another insurance policy", maturity: "20 years" }
    ];


    const policy = policies.find(p => p.id === policyId);  //filtering logic

    if (policy) {
        res.json(policy);
    } else {
        res.status(404).json({ message: "Policy not found" });
    }
});


app.listen(PORT, () => {
    console.log("Server is running on port 3000");
});