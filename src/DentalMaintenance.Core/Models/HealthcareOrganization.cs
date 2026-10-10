namespace DentalMaintenance.Core.Models;
public sealed class HealthcareOrganization
{
 public Guid Id { get; set; }=Guid.NewGuid(); public string OrganizationCode { get; set; }="";
 public string Name { get; set; }=""; public string OrganizationType { get; set; }="Clinic";
 public string? TimeZoneId { get; set; } public bool IsActive { get; set; }=true;
}