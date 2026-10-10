namespace DentalMaintenance.Core.Models;
public sealed class PatientCareProfile
{
 public Guid Id { get; set; }=Guid.NewGuid(); public Guid PatientId { get; set; } public string SpecialtyCode { get; set; }="GENERAL";
 public string Title { get; set; }="General Care Profile"; public Dictionary<string,string?> Fields { get; set; }=new();
 public DateTimeOffset UpdatedAt { get; set; }=DateTimeOffset.UtcNow;
}