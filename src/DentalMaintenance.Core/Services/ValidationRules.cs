namespace DentalMaintenance.Core.Services;
public static class ValidationRules
{
 public static bool IsValidAppointmentWindow(DateTimeOffset start,DateTimeOffset end)=>end>start;
 public static bool IsSafeExportText(string? value)=>string.IsNullOrEmpty(value)||value[0] is not ('=' or '+' or '-' or '@');
 public static bool HasRequiredText(string? value)=>!string.IsNullOrWhiteSpace(value);
}