using DentalMaintenance.Core.Services;
using Microsoft.AspNetCore.Mvc;
namespace DentalMaintenance.Api.Controllers;
[ApiController,Route("api/v1/algorithms")]
public sealed class AlgorithmsController:ControllerBase{[HttpGet]public IActionResult List()=>Ok(AlgorithmLibrary.Catalog);}