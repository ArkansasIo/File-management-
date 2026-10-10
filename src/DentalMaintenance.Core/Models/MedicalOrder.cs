namespace DentalMaintenance.Core.Models;
public sealed class MedicalOrder
{
 public Guid Id { get; set; }=Guid.NewGuid(); public Guid PatientId { get; set; } public Guid? EncounterId { get; set; }
 public string OrderType { get; set; }=""; public string Description { get; set; }=""; public string Status { get; set; }="Draft";
 public string OrderedBy { get; set; }=""; public DateTimeOffset OrderedAt { get; set; }=DateTimeOffset.UtcNow;
}