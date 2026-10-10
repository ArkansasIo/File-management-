namespace DentalMaintenance.Core.Models;
public sealed class Facility
{
 public Guid Id { get; set; }=Guid.NewGuid(); public Guid OrganizationId { get; set; }
 public string FacilityCode { get; set; }=""; public string Name { get; set; }="";
 public string? Address { get; set; } public bool IsActive { get; set; }=true;
}