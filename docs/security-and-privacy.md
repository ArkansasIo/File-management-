# Security and privacy readiness

This scaffold is not production-ready for personal health information. Before real data is entered:
- Implement OIDC/OAuth2 authentication and server-side authorization.
- Enforce organization/facility/patient-level access on every request.
- Use TLS, encrypt database volumes and backups, and manage secrets in a vault.
- Add audit events for reads, writes, exports, and printing.
- Add consent, disclosure, retention, correction, and breach-response workflows.
- Validate uploads, scan files, restrict file sizes/types, and store binaries outside the web root.
- Redact patient identifiers and clinical text from logs.
- Complete threat modeling, dependency scanning, penetration testing, backup/restore drills, and privacy/legal review.
