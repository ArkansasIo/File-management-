using DentalMaintenance.Core.Services;
using DentalMaintenance.Data;
using Microsoft.EntityFrameworkCore;
var builder=WebApplication.CreateBuilder(args);
builder.Services.AddControllers();builder.Services.AddEndpointsApiExplorer();builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<PatientChartTemplateRegistry>();builder.Services.AddSingleton<ChartValidationService>();
var connection=builder.Configuration.GetConnectionString("HealthcareDatabase");
if(!string.IsNullOrWhiteSpace(connection))builder.Services.AddDbContext<DentalDbContext>(o=>o.UseMySql(connection,ServerVersion.AutoDetect(connection)));
var app=builder.Build();
if(app.Environment.IsDevelopment()){app.UseSwagger();app.UseSwaggerUI();}
app.UseHttpsRedirection();
app.MapGet("/health",()=>Results.Ok(new{status="ok",product="DentalMaintenance Healthcare Workstation",version="1.0.0"}));
app.MapControllers();app.Run();