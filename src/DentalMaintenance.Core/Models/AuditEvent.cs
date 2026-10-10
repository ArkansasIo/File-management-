namespace DentalMaintenance.Core.Models;
public sealed class AuditEvent
{
 public Guid Id { get; set; }=Guid.NewGuid(); public string ActorId { get; set; }="system"; public string Action { get; set; }="";
 public string EntityType { get; set; }=""; public string EntityId { get; set; }=""; public DateTimeOffset OccurredAt { get; set; }=DateTimeOffset.UtcNow;
 public string? CorrelationId { get; set; } public string? DetailJson { get; set; }
}