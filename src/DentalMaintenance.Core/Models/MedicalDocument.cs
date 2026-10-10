namespace DentalMaintenance.Core.Models;
public sealed class MedicalDocument
{
 public Guid Id { get; set; }=Guid.NewGuid(); public Guid PatientId { get; set; } public string FileName { get; set; }="";
 public string MediaType { get; set; }="application/octet-stream"; public long SizeBytes { get; set; } public string StorageKey { get; set; }="";
 public string UploadedBy { get; set; }=""; public DateTimeOffset UploadedAt { get; set; }=DateTimeOffset.UtcNow;
}