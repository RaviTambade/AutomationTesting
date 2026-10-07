const express = require('express');
const jwt = require('jsonwebtoken');
const SECRET_KEY = 'your_secret_key';

const users = [
  { id: 1, username: 'ravit', password: 'password' },
  { id: 2, username: 'sameer', password: 'password' }
];



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


app.post('/api/login', (req, res) => {
  // Mock user authentication (replace with a real authentication logic)
  const { username, password } = req.body;
  const user = users.find(u => u.username === username && u.password === password);

  if (user) {
    // Generate a JWT token
    const token = jwt.sign({ id: user.id, username: user.username }, SECRET_KEY, { expiresIn: '1h' });
    res.json({ token });
  } else {
    res.status(401).json({ message: 'Invalid username or password' });
  }
});


function authenticateToken(req, res, next) {
  const authHeader = req.headers['authorization'];
  const token = authHeader && authHeader.split(' ')[1];

  if (!token) {
    return res.status(401).json({ message: 'Unauthorized' });
  }

  jwt.verify(token, SECRET_KEY, (err, user) => {
    if (err) {
      return res.status(403).json({ message: 'Forbidden' });
    }
    req.user = user;
    next();
  });
}


app.get('/api/userinfo', authenticateToken, (req, res) => {
  res.json({ id: req.user.id, username: req.user.username });
});

module.exports = app;