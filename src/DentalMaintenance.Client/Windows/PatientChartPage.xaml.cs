using DentalMaintenance.Core.Models;
using DentalMaintenance.Core.Services;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
namespace DentalMaintenance.Client.Windows;
public partial class PatientChartPage:UserControl
{
 private readonly PatientChartTemplateRegistry registry=new();
 private readonly ChartValidationService validator=new();
 private PatientChart? chart;
 public PatientChartPage(){InitializeComponent();SpecialtyBox.ItemsSource=registry.GetAll();SpecialtyBox.DisplayMemberPath="DisplayName";SpecialtyBox.SelectedValuePath="SpecialtyCode";SpecialtyBox.SelectedValue="GENERAL";}
 private void Create_Click(object sender,RoutedEventArgs e)
 {
  if(!Guid.TryParse(PatientIdBox.Text,out var id)||id==Guid.Empty){MessageBox.Show("Enter a valid patient GUID.");return;}
  if(SpecialtyBox.SelectedValue is not string specialty)return;
  try{chart=registry.Create(id,specialty);SectionsList.ItemsSource=chart.Sections;SectionsList.SelectedIndex=0;}catch(ArgumentException ex){MessageBox.Show(ex.Message);}
 }
 private void Sections_SelectionChanged(object sender,SelectionChangedEventArgs e){if(SectionsList.SelectedItem is PatientChartSection section)FieldsGrid.ItemsSource=section.Entries;}
 private void Validate_Click(object sender,RoutedEventArgs e){if(chart is null){MessageBox.Show("Create a chart first.");return;}var errors=validator.Validate(chart);MessageBox.Show(errors.Count==0?"Required fields passed validation.":string.Join(Environment.NewLine,errors),"Validation");}
 private void Print_Click(object sender,RoutedEventArgs e)
 {
  if(chart is null){MessageBox.Show("Create a chart first.");return;}
  var text=new PrintService().RenderText(BuildPrintDefinition());var dialog=new PrintDialog();
  if(dialog.ShowDialog()==true){var visual=new TextBlock{Text=text,TextWrapping=TextWrapping.Wrap,Margin=new Thickness(40),Width=700};visual.Measure(new Size(dialog.PrintableAreaWidth,dialog.PrintableAreaHeight));visual.Arrange(new Rect(new Point(0,0),visual.DesiredSize));dialog.PrintVisual(visual,"Patient Chart");}
 }
 private void Export_Click(object sender,RoutedEventArgs e){if(chart is null){MessageBox.Show("Create a chart first.");return;}var dialog=new SaveFileDialog{Filter="Text document (*.txt)|*.txt",FileName=$"{chart.ChartNumber}.txt"};if(dialog.ShowDialog()==true)File.WriteAllText(dialog.FileName,new PrintService().RenderText(BuildPrintDefinition()));}
 private PrintDocumentDefinition BuildPrintDefinition()=>new(){Title="Patient Chart",Subtitle=$"Specialty: {chart!.SpecialtyCode}",PatientIdentifier=chart.PatientId.ToString(),Sections=chart.Sections.Select(s=>new PrintSection{Heading=s.Title,Lines=s.Entries.Select(e=>$"{e.Label}: {e.Value}").ToList()}).ToList()};
}