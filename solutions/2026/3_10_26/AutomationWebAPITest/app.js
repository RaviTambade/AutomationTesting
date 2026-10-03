//AUT: Application under test

const express = require('express');
const app = express();

// Middleware
app.use(express.json());

// Hello World API
app.get('/', (req, res) => {
    res.status(200).send('Hello World!');
});


app.get('/api/health', (req, res) => {
  res.status(200).json({
        status: 'Success',
        message: 'API is running'
    });
});

app.post('/api/data', (req, res) => {
    const { name, age } = req.body;
    res.status(201).json({ name, age });
});


module.exports = app;