namespace DentalMaintenance.Core.Models;
public sealed class Patient
{
 public Guid Id { get; set; } = Guid.NewGuid();
 public string MedicalRecordNumber { get; set; } = "";
 public string GivenName { get; set; } = "";
 public string FamilyName { get; set; } = "";
 public DateOnly? DateOfBirth { get; set; }
 public string? PreferredName { get; set; }
 public string? Phone { get; set; }
 public string? Email { get; set; }
 public string? AddressLine1 { get; set; }
 public string? City { get; set; }
 public string? ProvinceOrState { get; set; }
 public string? PostalCode { get; set; }
 public string? CountryCode { get; set; } = "CA";
 public bool IsActive { get; set; } = true;
 public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
 public string DisplayName => $"{GivenName} {FamilyName}".Trim();
}