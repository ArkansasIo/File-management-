# Developer setup

1. Install .NET 8 SDK, Visual Studio 2022 with .NET desktop and ASP.NET workloads, and MySQL 8.
2. Apply the SQL files in `database/schema/` in numeric order.
3. Set `ConnectionStrings:HealthcareDatabase` through environment variables or .NET user-secrets.
4. Run `dotnet restore`, `dotnet build DentalMaintenance.sln`, and `dotnet test DentalMaintenance.sln`.
5. Run the API project and check `/health`; run the WPF client on Windows.

The project has not been compiled in this environment. The UI contains placeholder workspaces, and chart creation is currently in-memory only.
