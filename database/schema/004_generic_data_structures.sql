USE dental_maintenance;
CREATE TABLE IF NOT EXISTS terminology_definitions (
 id CHAR(36) PRIMARY KEY, terminology_system VARCHAR(100) NOT NULL, code VARCHAR(100) NOT NULL,
 display VARCHAR(255) NOT NULL, version VARCHAR(40) NULL, active BOOLEAN NOT NULL DEFAULT TRUE,
 UNIQUE KEY uq_terminology_code (terminology_system,code,version)
);
CREATE TABLE IF NOT EXISTS data_schema_definitions (
 id CHAR(36) PRIMARY KEY, schema_code VARCHAR(100) NOT NULL UNIQUE, display_name VARCHAR(200) NOT NULL,
 schema_version INT NOT NULL DEFAULT 1, schema_json JSON NOT NULL, is_active BOOLEAN NOT NULL DEFAULT TRUE,
 created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE IF NOT EXISTS algorithm_catalog (
 code VARCHAR(80) PRIMARY KEY, name VARCHAR(200) NOT NULL, category VARCHAR(100) NOT NULL,
 complexity VARCHAR(100) NOT NULL, implementation_status VARCHAR(32) NOT NULL, description TEXT NULL
);