using System.Windows;
namespace DentalMaintenance.Client.Windows;
public partial class HealthcareDesktopWindow:Window
{
 public HealthcareDesktopWindow()=>InitializeComponent();
 private void SetPage(string title,string body){PageTitle.Text=title;PageSubtitle.Text=body;WorkspaceText.Text=body;}
 private void Overview_Click(object s,RoutedEventArgs e)=>SetPage("Overview","Dashboard summary, data quality, and service status.");
 private void Patients_Click(object s,RoutedEventArgs e)=>SetPage("Patient Directory","Connect this workspace to /api/v1/patients; secure access checks are required.");
 private void Chart_Click(object s,RoutedEventArgs e)=>SetPage("Patient Charts","Specialty chart templates are available in the Core registry; chart persistence remains incomplete.");
 private void Appointments_Click(object s,RoutedEventArgs e)=>SetPage("Appointments","Scheduling workspace placeholder.");
 private void Encounters_Click(object s,RoutedEventArgs e)=>SetPage("Encounters","Encounter, notes, observations and orders workspace placeholder.");
 private void Documents_Click(object s,RoutedEventArgs e)=>SetPage("Documents","Secure document storage workflow placeholder.");
 private void Profiles_Click(object s,RoutedEventArgs e)=>SetPage("Care Profiles","Patient-specific care profile workspace placeholder.");
 private void Algorithms_Click(object s,RoutedEventArgs e)=>SetPage("Algorithms","Catalog metadata distinguishes implemented routines from reference entries.");
 private void Settings_Click(object s,RoutedEventArgs e)=>SetPage("Settings","Use local secrets for database credentials; never commit passwords.");
 private void Help_Click(object s,RoutedEventArgs e)=>MessageBox.Show("Development scaffold only. Do not use real patient data until security and persistence are implemented.","Help",MessageBoxButton.OK,MessageBoxImage.Information);
}