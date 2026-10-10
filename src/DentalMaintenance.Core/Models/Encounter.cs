namespace DentalMaintenance.Core.Models;
public sealed class Encounter
{
 public Guid Id { get; set; }=Guid.NewGuid(); public Guid PatientId { get; set; } public Guid ProviderId { get; set; } public Guid FacilityId { get; set; }
 public string EncounterType { get; set; }="OfficeVisit"; public DateTimeOffset StartedAt { get; set; }=DateTimeOffset.UtcNow;
 public DateTimeOffset? EndedAt { get; set; } public string Status { get; set; }="Open"; public string? ChiefConcern { get; set; }
 public string? Assessment { get; set; } public string? Plan { get; set; }
}