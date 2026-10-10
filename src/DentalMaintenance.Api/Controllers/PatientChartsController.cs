using DentalMaintenance.Core.Models;
using DentalMaintenance.Core.Services;
using Microsoft.AspNetCore.Mvc;
namespace DentalMaintenance.Api.Controllers;
[ApiController,Route("api/v1/patient-charts")]
public sealed class PatientChartsController(PatientChartTemplateRegistry templates,ChartValidationService validator):ControllerBase
{
 [HttpGet("templates")] public ActionResult<IReadOnlyCollection<PatientChartTemplate>> Templates()=>Ok(templates.GetAll());
 [HttpPost] public ActionResult<PatientChart> Create([FromBody] CreateChartRequest request)
 {
  if(request.PatientId==Guid.Empty)return BadRequest(new{message="PatientId is required."});
  try{return Ok(templates.Create(request.PatientId,request.SpecialtyCode));}
  catch(ArgumentException ex){return BadRequest(new{message=ex.Message});}
 }
 [HttpPost("validate")] public ActionResult Validate([FromBody] PatientChart chart)
 {
  var errors=validator.Validate(chart);
  return errors.Count==0?Ok(new{valid=true}):ValidationProblem(new Dictionary<string,string[]>{{"chart",errors.ToArray()}});
 }
}
public sealed record CreateChartRequest(Guid PatientId,string SpecialtyCode);