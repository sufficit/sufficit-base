# Monthly legacy renewal calculation

Added Sufficit.Sales.LegacyMonthlyRenewal.Calculate as a pure proposal over LegacyRenewalSnapshot.
Preserves independent start/billing advancement, source-calendar month-end expiration behavior,
value/commission (null mapped to zero as imported contract values), commissioned party and source
service identity. Shared-trunk adjustment uses inclusive collision at the proposed start and the
legacy 28..32-day window, moving start to predecessor end plus one day. No successor GUID is generated.

The caller supplies the source timezone and complete shared-trunk coverage for the same customer.
UTC values retain precision; Unspecified values use explicit timezone; machine-local or ambiguous
wall times are rejected. Missing billing evidence, renewed source, foreign coverage or inverted
intervals are rejected. This models generic monthly renewal only, not billed credit renewal.

Validation:25 tests passed across LegacyMonthlyRenewalTests and ContractMigrationTests. Includes
leap/non-leap month-end, ordinary dates and subsecond precision, independent billing, commission,
shared-trunk inclusive boundary, explicit timezone, missing/foreign evidence and deterministic replay.
Log: workspace tmp/legacy-monthly-renewal-tests.log.

Local implementation only. No production read/write/deployment or operational activation occurred.
Pending before cutover: transactional successor persistence with stable operation identity and
source version checks, recording predecessor completion atomically, durable equivalent telephony
effects, and legacy writer fence. Do not call the old renewal routine to deliver this proposal:
that would generate another service ID and can duplicate credit. Source timezone and coverage must
be established at the authoritative data boundary before using the proposal operationally.
