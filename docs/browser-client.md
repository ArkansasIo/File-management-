# Browser client and separate API

## Overview

The static client lives in `web/` and can be hosted on GitHub Pages or any static web host. The ASP.NET Core API remains a separate .NET 8 deployment. The browser client does not use a database connection and does not persist patient records locally.

## Run locally

Serve the `web/` directory with any static HTTP server. For example, from the repository root:

```bash
python -m http.server 8080 --directory web
```

Open `http://localhost:8080`, enter the HTTPS URL of the deployed API (or a local API URL), and select **Connect**. Do not use real patient data in a public or unapproved environment.

## API endpoints used

- `GET /health`: connectivity check.
- `GET /api/v1/patients?q={search}`: active patient search, capped at 100 records.
- `GET /api/v1/algorithms`: optional tool catalog integration.

The current repository's API uses the database context for patient endpoints. If no MySQL connection string is configured, database-backed endpoints are not ready for use. The document screen is intentionally a status page: secure document upload/download endpoints are not implemented yet.

## Cross-origin configuration

Configure `Cors:AllowedOrigins` on the API deployment with exact origin strings and no trailing slash, for example:

```json
{
  "Cors": {
    "AllowedOrigins": [
      "https://YOUR-ACCOUNT.github.io"
    ]
  }
}
```

GitHub Pages project sites normally share the account's origin, so use the origin only—not the project path. For local development, add the exact local origin such as `http://localhost:8080`. Environment-variable equivalent: `Cors__AllowedOrigins__0`. Add additional indexed values for additional origins. Do not use wildcard origins for a healthcare system. See [Microsoft's ASP.NET Core CORS guidance](https://learn.microsoft.com/en-us/aspnet/core/security/cors).

## GitHub Pages setup

1. Open repository **Settings → Pages**.
2. Select **Deploy from a branch**.
3. Select branch `feature/browser-client-api` and folder `/web` for a preview, or merge the changes to `main` and select `main` / `/web`.
4. Wait for the Pages deployment and open the published URL.
5. Deploy the API separately with HTTPS, database configuration, authentication, authorization, and audit logging.

A static client is public code. Never embed API secrets, database credentials, signing keys, or private configuration in `web/`.

## Security and production readiness

This repository is a development scaffold, not a certified electronic health record. Before real patient information is used, implement and independently review authentication, authorization, tenant isolation, audit enforcement, secure document storage, data retention, backup/recovery, and applicable privacy/legal controls. CORS is a browser policy, not authentication or authorization. Do not treat the algorithms catalogue as clinical advice.
