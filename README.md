# DentalMaintenance Healthcare Workstation

A C#/.NET 8 starter repository for a Windows-style, multi-specialty healthcare maintenance workstation.

## Projects
- `src/DentalMaintenance.Core`: domain models, validation, specialty templates, printing, algorithm examples.
- `src/DentalMaintenance.Data`: Entity Framework Core / MySQL context.
- `src/DentalMaintenance.Api`: ASP.NET Core API.
- `src/DentalMaintenance.Client`: WPF desktop shell and patient chart editor.
- `database/`: MySQL schemas, seed data, views, functions, and procedures.
- `excel/`: CSV templates and formula examples.
- `docs/`: architecture, API, privacy/security, chart, testing, and operations docs.
- `tests/`: unit tests.

## Build
Install the .NET 8 SDK and, on Windows, the .NET desktop workload. Then run:
```powershell
dotnet restore DentalMaintenance.sln
dotnet build DentalMaintenance.sln
dotnet test DentalMaintenance.sln
```

Configure MySQL through environment-specific configuration or .NET user-secrets. Never commit real credentials.

## Important limitations
This is a development scaffold, not a certified electronic health record. Patient chart template creation currently runs in memory and is not persisted by the chart API. Authentication, authorization, audit enforcement, secure document storage, tenant isolation, and production-grade PHI safeguards must be implemented and independently tested before real patient information is used. The algorithm catalog includes reference-only entries; those are labelled as such.
