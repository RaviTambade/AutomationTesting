///import  required modules



const express = require('express');
const authRoutes = require('./routes/auth');
const { authenticateToken } = require('./middleware/authMiddleware');


// Define the Express app

const app = express();


//Set up middleware and routes

app.use(express.json());

app.use('/api/auth', authRoutes);
app.use((error, req, res, next) => {
    console.error(error);
    res.status(500).json({ error: 'Internal server error' });
});


app.get('/', (req, res) => {
    res.status(200).send('Hello World!');
});

app.get('/api/health', (req, res) => {
    res.status(200).json({
        status: 'Success',
        message: 'API is running'
    });
});

app.post('/api/data', authenticateToken, (req, res) => {
    const { name, age } = req.body;
    res.status(201).json({ name, age });
});

module.exports = app;
