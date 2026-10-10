namespace DentalMaintenance.Core.Models;
public sealed class ClinicalObservation
{
 public Guid Id { get; set; }=Guid.NewGuid(); public Guid PatientId { get; set; } public Guid? EncounterId { get; set; }
 public string Code { get; set; }=""; public string DisplayName { get; set; }=""; public string? ValueText { get; set; }
 public decimal? ValueNumeric { get; set; } public string? Unit { get; set; } public DateTimeOffset ObservedAt { get; set; }=DateTimeOffset.UtcNow;
 public string? RecordedBy { get; set; }
}