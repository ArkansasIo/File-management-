# Spreadsheet formula examples

Assuming an Excel table named `Patients`:
- Age in years: `=IF([@DateOfBirth]="","",DATEDIF([@DateOfBirth],TODAY(),"Y"))`
- Full display name: `=TRIM([@GivenName]&" "&[@FamilyName])`
- Missing MRN flag: `=IF(TRIM([@MedicalRecordNumber])="","MISSING","OK")`
- Appointment duration in minutes: `=IF(OR([@StartsAt]="",[@EndsAt]=""),"",([@EndsAt]-[@StartsAt])*1440)`

These are operational examples, not clinical rules. Validate date/time handling and prevent spreadsheet formula injection when exporting untrusted text.
