# Architecture

The solution separates Core domain models and rules, Data persistence, ASP.NET Core API endpoints, and the WPF desktop client. SQL schema is maintained separately in ordered files.

- Core: domain models, specialty templates, validation, print rendering, algorithm catalog.
- Data: EF Core context and MySQL provider.
- API: versioned HTTP controllers and health endpoint.
- Client: WPF workstation shell.
- Database: schema, seed data, views, functions, and procedures.

Before production, add authentication and authorization, tenant-scoped access, audited writes and exports, database migrations, secure document storage, monitoring, and backup/restore processes.
