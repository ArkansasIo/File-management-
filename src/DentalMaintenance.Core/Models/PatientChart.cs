namespace DentalMaintenance.Core.Models;
public sealed class PatientChart
{
 public Guid Id { get; set; } = Guid.NewGuid();
 public Guid PatientId { get; set; }
 public string ChartNumber { get; set; } = "";
 public string SpecialtyCode { get; set; } = "GENERAL";
 public string Status { get; set; } = "Open";
 public List<PatientChartSection> Sections { get; set; } = new();
 public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
 public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
public sealed class PatientChartSection
{
 public Guid Id { get; set; } = Guid.NewGuid();
 public string SectionCode { get; set; } = "";
 public string Title { get; set; } = "";
 public int SortOrder { get; set; }
 public List<PatientChartEntry> Entries { get; set; } = new();
}
public sealed class PatientChartEntry
{
 public Guid Id { get; set; } = Guid.NewGuid();
 public string FieldCode { get; set; } = "";
 public string Label { get; set; } = "";
 public string? Value { get; set; }
 public string DataType { get; set; } = "text";
 public bool Required { get; set; }
}