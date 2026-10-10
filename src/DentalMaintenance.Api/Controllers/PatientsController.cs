using DentalMaintenance.Core.Models;
using DentalMaintenance.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DentalMaintenance.Api.Controllers;
[ApiController,Route("api/v1/patients")]
public sealed class PatientsController(DentalDbContext db):ControllerBase
{
 [HttpGet] public async Task<ActionResult<IReadOnlyList<Patient>>> List([FromQuery]string? q,CancellationToken ct)
 {
  var query=db.Patients.AsNoTracking().Where(x=>x.IsActive);
  if(!string.IsNullOrWhiteSpace(q))query=query.Where(x=>x.MedicalRecordNumber.Contains(q)||x.GivenName.Contains(q)||x.FamilyName.Contains(q));
  return Ok(await query.OrderBy(x=>x.FamilyName).ThenBy(x=>x.GivenName).Take(100).ToListAsync(ct));
 }
 [HttpGet("{id:guid}")] public async Task<ActionResult<Patient>> Get(Guid id,CancellationToken ct){var p=await db.Patients.AsNoTracking().SingleOrDefaultAsync(x=>x.Id==id,ct);return p is null?NotFound():Ok(p);}
 [HttpPost] public async Task<ActionResult<Patient>> Create(Patient patient,CancellationToken ct)
 {
  if(string.IsNullOrWhiteSpace(patient.MedicalRecordNumber)||string.IsNullOrWhiteSpace(patient.GivenName)||string.IsNullOrWhiteSpace(patient.FamilyName))return ValidationProblem("Medical record number, given name, and family name are required.");
  patient.Id=Guid.NewGuid();patient.CreatedAt=DateTimeOffset.UtcNow;db.Patients.Add(patient);
  try{await db.SaveChangesAsync(ct);}catch(DbUpdateException){return Conflict(new{message="Could not save; verify unique identifiers."});}
  return CreatedAtAction(nameof(Get),new{id=patient.Id},patient);
 }
}