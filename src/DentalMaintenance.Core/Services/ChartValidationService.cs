using DentalMaintenance.Core.Models;
namespace DentalMaintenance.Core.Services;
public sealed class ChartValidationService
{
 public IReadOnlyList<string> Validate(PatientChart chart)
 {
  var errors = new List<string>();
  if (chart.PatientId == Guid.Empty) errors.Add("A patient must be selected.");
  if (string.IsNullOrWhiteSpace(chart.SpecialtyCode)) errors.Add("Specialty code is required.");
  foreach (var field in chart.Sections.SelectMany(s => s.Entries))
   if (field.Required && string.IsNullOrWhiteSpace(field.Value)) errors.Add($"{field.Label} is required.");
  return errors;
 }
}