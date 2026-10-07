# AutomationWebAPITest

## Run the API

Set `JWT_SECRET` to a private value of at least 32 characters before starting the
server. For example, in PowerShell:

```powershell
$env:JWT_SECRET = node -e "console.log(require('crypto').randomBytes(48).toString('hex'))"
npm start
```

The API refuses to start when the signing key is missing or too short. Keep the
key private and do not commit it.

## Authentication

- `POST /api/auth/register` accepts `{"email":"user@example.com","password":"a-long-password"}`.
- `POST /api/auth/login` accepts the same fields.
- Both successful responses include a user object and a JWT valid for one hour.
- `POST /api/data` requires `Authorization: Bearer <token>`.
- `GET /` and `GET /api/health` remain public.

Passwords are bcrypt-hashed before being written to `users.json`; plaintext
passwords are never stored or returned. The JSON file is ignored by Git because
it contains credential-derived data. It is a lightweight local-development
store, not a concurrent or production database.
