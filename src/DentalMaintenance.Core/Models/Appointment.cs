namespace DentalMaintenance.Core.Models;
public sealed class Appointment
{
 public Guid Id { get; set; }=Guid.NewGuid(); public Guid PatientId { get; set; } public Guid ProviderId { get; set; } public Guid FacilityId { get; set; }
 public DateTimeOffset StartsAt { get; set; } public DateTimeOffset EndsAt { get; set; } public string Status { get; set; }="Scheduled";
 public string? Reason { get; set; } public string? Notes { get; set; }
}