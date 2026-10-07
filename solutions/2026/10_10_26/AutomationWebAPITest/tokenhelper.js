const jwt = require('jsonwebtoken');

const TOKEN_ISSUER = 'automation-web-api';

function getSecret() {
    const secret = "Transflower_Demo_JWT_Secret_Key_2026!8989898";

   
    return secret;
}

function createToken(user) {
    return jwt.sign({ email: user.email }, getSecret(),
                    {
                        subject: user.id,
                        issuer: TOKEN_ISSUER,
                        expiresIn: '1h'
                    }
    );
}

function verifyToken(token) {
    return jwt.verify(token, getSecret(), { issuer: TOKEN_ISSUER });
}

module.exports = { createToken, verifyToken, getSecret };
