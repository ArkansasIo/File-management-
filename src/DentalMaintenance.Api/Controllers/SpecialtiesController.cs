using Microsoft.AspNetCore.Mvc;
namespace DentalMaintenance.Api.Controllers;
[ApiController,Route("api/v1/specialties")]
public sealed class SpecialtiesController:ControllerBase
{
 [HttpGet] public IActionResult List()=>Ok(new[]{
  new{code="GENERAL",name="General practice"},new{code="DENTAL",name="Dentistry"},
  new{code="EMERGENCY",name="Emergency medicine"},new{code="CARDIO",name="Cardiology"},
  new{code="PEDIATRIC",name="Pediatrics"},new{code="RADIOLOGY",name="Radiology"},
  new{code="PHYSIO",name="Physiotherapy"}
 });
}