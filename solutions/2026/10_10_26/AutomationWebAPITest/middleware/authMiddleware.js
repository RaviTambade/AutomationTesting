const jwt = require('jsonwebtoken');
const { getSecret, verifyToken } = require('../tokenhelper');

function authenticateToken(req, res, next) {
    const authorization = req.get('authorization');
    const [scheme, token] = authorization ? authorization.split(' ') : [];

    if (scheme !== 'Bearer' || !token) {
        return res.status(401).json({ error: 'Bearer token required' });
    }

    getSecret();

    try {
        req.auth = verifyToken(token);
        return next();
    } catch (error) {
        if (error instanceof jwt.JsonWebTokenError) {
            return res.status(401).json({ error: 'Invalid or expired token' });
        }

        return next(error);
    }
}

module.exports = { authenticateToken };
