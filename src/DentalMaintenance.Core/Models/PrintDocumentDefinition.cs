namespace DentalMaintenance.Core.Models;
public sealed class PrintDocumentDefinition
{
 public string Title { get; set; } = "Patient Document";
 public string? Subtitle { get; set; }
 public string? PatientIdentifier { get; set; }
 public string? FacilityName { get; set; }
 public DateTimeOffset GeneratedAt { get; set; } = DateTimeOffset.UtcNow;
 public List<PrintSection> Sections { get; set; } = new();
}
public sealed class PrintSection { public string Heading { get; set; } = ""; public List<string> Lines { get; set; } = new(); }