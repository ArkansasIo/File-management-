USE dental_maintenance;
CREATE OR REPLACE VIEW v_patient_directory AS
SELECT id,medical_record_number,given_name,family_name,preferred_name,date_of_birth,phone,email,is_active,created_at
FROM patients;