using DentalMaintenance.Core.Models;
namespace DentalMaintenance.Core.Services;
public sealed class PatientChartTemplateRegistry
{
 private readonly Dictionary<string, PatientChartTemplate> _templates;
 public PatientChartTemplateRegistry() => _templates = new[] { General(), Dental(), Emergency(), Cardiology(), Pediatrics(), Radiology(), Physiotherapy() }.ToDictionary(x => x.SpecialtyCode, StringComparer.OrdinalIgnoreCase);
 public IReadOnlyCollection<PatientChartTemplate> GetAll() => _templates.Values.OrderBy(x => x.DisplayName).ToArray();
 public PatientChartTemplate? Find(string code) => _templates.GetValueOrDefault(code);
 public PatientChart Create(Guid patientId, string specialtyCode)
 {
  var t = Find(specialtyCode) ?? throw new ArgumentException($"Unknown specialty code: {specialtyCode}", nameof(specialtyCode));
  var chart = new PatientChart { PatientId = patientId, SpecialtyCode = t.SpecialtyCode, ChartNumber = $"{t.SpecialtyCode}-{Guid.NewGuid():N}"[..(t.SpecialtyCode.Length + 9)] };
  chart.Sections = t.Sections.Select(s => new PatientChartSection { SectionCode=s.SectionCode, Title=s.Title, SortOrder=s.SortOrder, Entries=s.Fields.Select(f=>new PatientChartEntry { FieldCode=f.FieldCode, Label=f.Label, DataType=f.DataType, Required=f.Required }).ToList() }).ToList();
  return chart;
 }
 private static PatientChartTemplate General()=>T("GENERAL","General Care",S("overview","Overview",1,F("chief_concern","Chief concern",true),F("history","History")),S("assessment","Assessment and plan",2,F("assessment","Assessment"),F("plan","Plan")));
 private static PatientChartTemplate Dental()=>T("DENTAL","Dental",S("oral_history","Oral history",1,F("chief_concern","Chief concern",true),F("pain_scale","Pain scale"),F("allergies","Allergies")),S("exam","Oral examination",2,F("teeth","Teeth / dentition"),F("periodontal","Periodontal findings"),F("imaging","Imaging notes")),S("plan","Treatment plan",3,F("diagnosis","Diagnosis"),F("treatment","Planned treatment")));
 private static PatientChartTemplate Emergency()=>T("EMERGENCY","Emergency",S("triage","Triage",1,F("arrival_mode","Arrival mode",true),F("acuity","Acuity",true),F("chief_concern","Chief concern",true)),S("assessment","Assessment",2,F("vitals","Vital signs"),F("interventions","Interventions"),F("disposition","Disposition")));
 private static PatientChartTemplate Cardiology()=>T("CARDIO","Cardiology",S("history","Cardiac history",1,F("symptoms","Symptoms"),F("risk_factors","Risk factors")),S("exam","Examination and tests",2,F("ecg","ECG summary"),F("imaging","Imaging summary"),F("assessment","Assessment")));
 private static PatientChartTemplate Pediatrics()=>T("PEDIATRIC","Pediatrics",S("growth","Growth and development",1,F("height","Height"),F("weight","Weight"),F("development","Development")),S("visit","Visit",2,F("guardian","Guardian present"),F("concern","Caregiver concern"),F("plan","Plan")));
 private static PatientChartTemplate Radiology()=>T("RADIOLOGY","Radiology",S("request","Study request",1,F("modality","Modality",true),F("body_site","Body site",true),F("indication","Indication")),S("report","Report",2,F("findings","Findings"),F("impression","Impression"),F("follow_up","Follow-up")));
 private static PatientChartTemplate Physiotherapy()=>T("PHYSIO","Physiotherapy",S("function","Functional assessment",1,F("pain","Pain"),F("mobility","Mobility"),F("goals","Patient goals")),S("session","Session plan",2,F("interventions","Interventions"),F("home_program","Home program"),F("response","Response")));
 private static PatientChartTemplate T(string c,string n,params PatientChartSectionTemplate[] s)=>new(){SpecialtyCode=c,DisplayName=n,Sections=s.ToList()};
 private static PatientChartSectionTemplate S(string c,string t,int o,params PatientChartFieldTemplate[] f)=>new(){SectionCode=c,Title=t,SortOrder=o,Fields=f.ToList()};
 private static PatientChartFieldTemplate F(string c,string l,bool r=false,string d="text")=>new(){FieldCode=c,Label=l,Required=r,DataType=d};
}