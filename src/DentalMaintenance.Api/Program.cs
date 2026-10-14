using DentalMaintenance.Core.Services;
using DentalMaintenance.Data;
using Microsoft.EntityFrameworkCore;

const string BrowserClientCorsPolicy = "BrowserClient";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<PatientChartTemplateRegistry>();
builder.Services.AddSingleton<ChartValidationService>();

var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(BrowserClientCorsPolicy, policy =>
    {
        if (allowedOrigins.Length > 0)
        {
            policy.WithOrigins(allowedOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    });
});

var connection = builder.Configuration.GetConnectionString("HealthcareDatabase");
if (!string.IsNullOrWhiteSpace(connection))
{
    builder.Services.AddDbContext<DentalDbContext>(options =>
        options.UseMySql(connection, ServerVersion.AutoDetect(connection)));
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(BrowserClientCorsPolicy);

app.MapGet("/health", () => Results.Ok(new
{
    status = "ok",
    product = "DentalMaintenance Healthcare Workstation",
    version = "1.0.0"
})).WithName("HealthCheck");

app.MapControllers();
app.Run();

public partial class Program;
