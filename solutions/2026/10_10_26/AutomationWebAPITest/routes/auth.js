const { randomUUID } = require('crypto');
const express = require('express');
const bcrypt = require('bcryptjs');
const { createToken, getSecret } = require('../tokenhelper');
const { readUsers, writeUsers } = require('../userStore');

const router = express.Router();
const EMAIL_PATTERN = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

function normalizeCredentials(body = {}) {
    const email = typeof body.email === 'string' ? body.email.trim().toLowerCase() : '';
    const password = typeof body.password === 'string' ? body.password : '';

    if (!EMAIL_PATTERN.test(email) || password.length < 8) {
        return null;
    }

    return { email, password };
}

router.post('/register', async (req, res, next) => {
    const credentials = normalizeCredentials(req.body);
    if (!credentials) {
        return res.status(400).json({
            error: 'A valid email and a password of at least 8 characters are required'
        });
    }

    try {
        getSecret();
        const users = readUsers();
        if (users.some((user) => user.email === credentials.email)) {
            return res.status(409).json({ error: 'An account with this email already exists' });
        }

        const user = {
            id: randomUUID(),
            email: credentials.email,
            passwordHash: await bcrypt.hash(credentials.password, 12)
        };

        users.push(user);
        writeUsers(users);

        return res.status(201).json({
            user: { id: user.id, email: user.email },
            token: createToken(user)
        });
    } catch (error) {
        return next(error);
    }
});

router.post('/login', async (req, res, next) => {
    const credentials = normalizeCredentials(req.body);
    if (!credentials) {
        return res.status(400).json({
            error: 'A valid email and a password of at least 8 characters are required'
        });
    }

    try {
        getSecret();
        const user = readUsers().find((candidate) => candidate.email === credentials.email);
        if (!user || !(await bcrypt.compare(credentials.password, user.passwordHash))) {
            return res.status(401).json({ error: 'Invalid email or password' });
        }

        return res.status(200).json({
            user: { id: user.id, email: user.email },
            token: createToken(user)
        });
    } catch (error) {
        return next(error);
    }
});

module.exports = router;
