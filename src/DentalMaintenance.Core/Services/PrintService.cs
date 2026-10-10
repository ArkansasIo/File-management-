using DentalMaintenance.Core.Models;
using System.Text;
namespace DentalMaintenance.Core.Services;
public sealed class PrintService
{
 public string RenderText(PrintDocumentDefinition document)
 {
  var b=new StringBuilder();b.AppendLine(document.Title);
  if(!string.IsNullOrWhiteSpace(document.Subtitle))b.AppendLine(document.Subtitle);
  if(!string.IsNullOrWhiteSpace(document.PatientIdentifier))b.AppendLine($"Patient: {document.PatientIdentifier}");
  if(!string.IsNullOrWhiteSpace(document.FacilityName))b.AppendLine($"Facility: {document.FacilityName}");
  b.AppendLine($"Generated: {document.GeneratedAt:yyyy-MM-dd HH:mm} UTC");b.AppendLine(new string('=',72));
  foreach(var section in document.Sections){b.AppendLine();b.AppendLine(section.Heading);b.AppendLine(new string('-',section.Heading.Length));foreach(var line in section.Lines)b.AppendLine(line);}
  return b.ToString();
 }
 public Task ExportTextAsync(PrintDocumentDefinition document,string path,CancellationToken ct=default)=>File.WriteAllTextAsync(path,RenderText(document),Encoding.UTF8,ct);
}