namespace DentalMaintenance.Core.Models;
public sealed class ClinicalNote
{
 public Guid Id { get; set; }=Guid.NewGuid(); public Guid PatientId { get; set; } public Guid? EncounterId { get; set; }
 public string NoteType { get; set; }="General"; public string Body { get; set; }=""; public string Status { get; set; }="Draft";
 public string AuthorId { get; set; }=""; public DateTimeOffset CreatedAt { get; set; }=DateTimeOffset.UtcNow; public DateTimeOffset? SignedAt { get; set; }
}