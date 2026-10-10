USE dental_maintenance;
CREATE TABLE IF NOT EXISTS medical_documents (
 id CHAR(36) PRIMARY KEY, patient_id CHAR(36) NOT NULL, file_name VARCHAR(255) NOT NULL,
 media_type VARCHAR(150) NOT NULL, size_bytes BIGINT NOT NULL, storage_key VARCHAR(500) NOT NULL,
 uploaded_by VARCHAR(100) NOT NULL, uploaded_at DATETIME(6) NOT NULL,
 INDEX ix_document_patient_date (patient_id,uploaded_at),
 CONSTRAINT fk_document_patient FOREIGN KEY (patient_id) REFERENCES patients(id)
);
CREATE TABLE IF NOT EXISTS audit_events (
 id CHAR(36) PRIMARY KEY, actor_id VARCHAR(100) NOT NULL, action VARCHAR(100) NOT NULL,
 entity_type VARCHAR(100) NOT NULL, entity_id VARCHAR(100) NOT NULL, occurred_at DATETIME(6) NOT NULL,
 correlation_id VARCHAR(100) NULL, detail_json JSON NULL,
 INDEX ix_audit_entity_date (entity_type,entity_id,occurred_at)
);