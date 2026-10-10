namespace DentalMaintenance.Core.Services;
public sealed record SpecialtyDefinition(string Code,string Name,string ChartTemplateCode);
public static class HealthcareRegistry
{
 public static IReadOnlyList<SpecialtyDefinition> Specialties { get; }=new[]{
  new SpecialtyDefinition("GENERAL","General practice","GENERAL"),
  new SpecialtyDefinition("DENTAL","Dentistry","DENTAL"),
  new SpecialtyDefinition("EMERGENCY","Emergency medicine","EMERGENCY"),
  new SpecialtyDefinition("CARDIO","Cardiology","CARDIO"),
  new SpecialtyDefinition("PEDIATRIC","Pediatrics","PEDIATRIC"),
  new SpecialtyDefinition("RADIOLOGY","Radiology","RADIOLOGY"),
  new SpecialtyDefinition("PHYSIO","Physiotherapy","PHYSIO")
 };
}