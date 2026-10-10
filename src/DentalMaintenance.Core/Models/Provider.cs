namespace DentalMaintenance.Core.Models;
public sealed class Provider
{
 public Guid Id { get; set; }=Guid.NewGuid(); public Guid FacilityId { get; set; }
 public string ProviderNumber { get; set; }=""; public string DisplayName { get; set; }="";
 public string SpecialtyCode { get; set; }="GENERAL"; public string? LicenseNumber { get; set; } public bool IsActive { get; set; }=true;
}