CREATE DATABASE IF NOT EXISTS dental_maintenance CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE dental_maintenance;
CREATE TABLE IF NOT EXISTS patients (
 id CHAR(36) PRIMARY KEY, medical_record_number VARCHAR(64) NOT NULL UNIQUE,
 given_name VARCHAR(120) NOT NULL, family_name VARCHAR(120) NOT NULL, preferred_name VARCHAR(120) NULL,
 date_of_birth DATE NULL, phone VARCHAR(40) NULL, email VARCHAR(254) NULL, address_line1 VARCHAR(200) NULL,
 city VARCHAR(120) NULL, province_or_state VARCHAR(120) NULL, postal_code VARCHAR(24) NULL,
 country_code CHAR(2) NULL DEFAULT 'CA', is_active BOOLEAN NOT NULL DEFAULT TRUE,
 created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, INDEX ix_patient_name (family_name,given_name)
);