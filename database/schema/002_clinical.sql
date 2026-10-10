USE dental_maintenance;
CREATE TABLE IF NOT EXISTS appointments (
 id CHAR(36) PRIMARY KEY, patient_id CHAR(36) NOT NULL, provider_id CHAR(36) NOT NULL, facility_id CHAR(36) NOT NULL,
 starts_at DATETIME(6) NOT NULL, ends_at DATETIME(6) NOT NULL, status VARCHAR(32) NOT NULL DEFAULT 'Scheduled',
 reason VARCHAR(500) NULL, notes TEXT NULL, created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
 INDEX ix_appointment_patient (patient_id,starts_at), CONSTRAINT fk_appointment_patient FOREIGN KEY (patient_id) REFERENCES patients(id)
);
CREATE TABLE IF NOT EXISTS encounters (
 id CHAR(36) PRIMARY KEY, patient_id CHAR(36) NOT NULL, provider_id CHAR(36) NOT NULL, facility_id CHAR(36) NOT NULL,
 encounter_type VARCHAR(64) NOT NULL, started_at DATETIME(6) NOT NULL, ended_at DATETIME(6) NULL,
 status VARCHAR(32) NOT NULL DEFAULT 'Open', chief_concern TEXT NULL, assessment TEXT NULL, plan TEXT NULL,
 INDEX ix_encounter_patient_start (patient_id,started_at), CONSTRAINT fk_encounter_patient FOREIGN KEY (patient_id) REFERENCES patients(id)
);
CREATE TABLE IF NOT EXISTS clinical_observations (
 id CHAR(36) PRIMARY KEY, patient_id CHAR(36) NOT NULL, encounter_id CHAR(36) NULL, code VARCHAR(100) NOT NULL,
 display_name VARCHAR(200) NOT NULL, value_text TEXT NULL, value_numeric DECIMAL(18,6) NULL, unit VARCHAR(40) NULL,
 observed_at DATETIME(6) NOT NULL, recorded_by VARCHAR(100) NULL,
 INDEX ix_observation_patient_date (patient_id,observed_at), CONSTRAINT fk_observation_patient FOREIGN KEY (patient_id) REFERENCES patients(id)
);
CREATE TABLE IF NOT EXISTS clinical_notes (
 id CHAR(36) PRIMARY KEY, patient_id CHAR(36) NOT NULL, encounter_id CHAR(36) NULL, note_type VARCHAR(64) NOT NULL,
 body LONGTEXT NOT NULL, status VARCHAR(32) NOT NULL DEFAULT 'Draft', author_id VARCHAR(100) NOT NULL,
 created_at DATETIME(6) NOT NULL, signed_at DATETIME(6) NULL,
 INDEX ix_note_patient_date (patient_id,created_at), CONSTRAINT fk_note_patient FOREIGN KEY (patient_id) REFERENCES patients(id)
);