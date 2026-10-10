USE dental_maintenance;
CREATE TABLE IF NOT EXISTS patient_charts (
 id CHAR(36) PRIMARY KEY, patient_id CHAR(36) NOT NULL, chart_number VARCHAR(100) NOT NULL UNIQUE,
 specialty_code VARCHAR(64) NOT NULL, status VARCHAR(32) NOT NULL DEFAULT 'Open',
 created_at DATETIME(6) NOT NULL, updated_at DATETIME(6) NOT NULL,
 INDEX ix_chart_patient_specialty (patient_id,specialty_code),
 CONSTRAINT fk_chart_patient FOREIGN KEY (patient_id) REFERENCES patients(id)
);
CREATE TABLE IF NOT EXISTS patient_chart_sections (
 id CHAR(36) PRIMARY KEY, chart_id CHAR(36) NOT NULL, section_code VARCHAR(100) NOT NULL,
 title VARCHAR(200) NOT NULL, sort_order INT NOT NULL, UNIQUE KEY uq_chart_section (chart_id,section_code),
 CONSTRAINT fk_chart_section_chart FOREIGN KEY (chart_id) REFERENCES patient_charts(id) ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS patient_chart_entries (
 id CHAR(36) PRIMARY KEY, section_id CHAR(36) NOT NULL, field_code VARCHAR(100) NOT NULL,
 label VARCHAR(200) NOT NULL, value_text LONGTEXT NULL, data_type VARCHAR(40) NOT NULL DEFAULT 'text',
 is_required BOOLEAN NOT NULL DEFAULT FALSE, UNIQUE KEY uq_section_field (section_id,field_code),
 CONSTRAINT fk_chart_entry_section FOREIGN KEY (section_id) REFERENCES patient_chart_sections(id) ON DELETE CASCADE
);