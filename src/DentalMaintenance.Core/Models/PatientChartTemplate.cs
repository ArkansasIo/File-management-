namespace DentalMaintenance.Core.Models;
public sealed class PatientChartTemplate
{
 public string SpecialtyCode { get; set; } = "GENERAL";
 public string DisplayName { get; set; } = "General";
 public List<PatientChartSectionTemplate> Sections { get; set; } = new();
}
public sealed class PatientChartSectionTemplate
{
 public string SectionCode { get; set; } = "";
 public string Title { get; set; } = "";
 public int SortOrder { get; set; }
 public List<PatientChartFieldTemplate> Fields { get; set; } = new();
}
public sealed class PatientChartFieldTemplate
{
 public string FieldCode { get; set; } = "";
 public string Label { get; set; } = "";
 public string DataType { get; set; } = "text";
 public bool Required { get; set; }
}