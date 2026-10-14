# Deployment: browser client + backend API

## Architecture

- **Frontend:** static HTML/CSS/JavaScript in `web/`; suitable for GitHub Pages.
- **Backend:** ASP.NET Core 8 API in `src/DentalMaintenance.Api`; deploy to an ASP.NET Core-capable host.
- **Database:** MySQL via Entity Framework Core, configured by the API host's `ConnectionStrings:HealthcareDatabase`.

GitHub Pages cannot execute the .NET API or connect directly to MySQL. The browser must call the separately deployed API over HTTPS.

## Configuration

Set the following on the API host:

- `ConnectionStrings__HealthcareDatabase`: secret MySQL connection string.
- `Cors__AllowedOrigins__0`: exact published website origin, e.g. `https://YOUR-ACCOUNT.github.io`.
- `ASPNETCORE_ENVIRONMENT`: use `Production` in production.

Never commit secrets or put them in browser-side files. Do not allow every origin in production. Configure TLS, authentication, authorization, database migrations, monitoring, backups and audit retention before production.

## GitHub Pages

Publish the `web/` directory as the Pages artifact. For a project site, its URL is commonly `https://OWNER.github.io/REPOSITORY/`; the CORS origin is only `https://OWNER.github.io` (without the repository path). The client API URL is entered at runtime, avoiding a rebuild to change environments.

## Verification

Run browser-client static tests with Node.js 20 or later:

```bash
node --test tests/browser-client.test.mjs
```

Run the .NET build and test suite:

```bash
dotnet restore DentalMaintenance.sln
dotnet build DentalMaintenance.sln --configuration Release --no-restore
dotnet test DentalMaintenance.sln --configuration Release --no-build
```

A green static-client test does not verify API integration or clinical safety. Those require deployed integration tests and a formal security review.
