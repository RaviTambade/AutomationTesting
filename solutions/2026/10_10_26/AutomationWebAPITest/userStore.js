const fs = require('fs');
const path = require('path');

function getUsersFilePath() {
    return process.env.USERS_FILE || path.join(__dirname, 'users.json');
}

function readUsers() {
    const filePath = getUsersFilePath();

    if (!fs.existsSync(filePath)) {
        fs.mkdirSync(path.dirname(filePath), { recursive: true });
        fs.writeFileSync(filePath, '[]\n', { flag: 'wx' });
    }

    const users = JSON.parse(fs.readFileSync(filePath, 'utf8'));
    if (!Array.isArray(users)) {
        throw new Error('users.json must contain a JSON array');
    }

    return users;
}

function writeUsers(users) {
    fs.writeFileSync(getUsersFilePath(), `${JSON.stringify(users, null, 2)}\n`);
}

module.exports = { readUsers, writeUsers };
