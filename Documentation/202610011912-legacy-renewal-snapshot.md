# Last legacy service identity for renewal handoff

SalesRuntime.MigrateContracts aggregates renewal chains. Contract.Start is the first member,
Contract.End the latest end, and Contract.Id may be a new destination GUID. These fields cannot
identify the last service that must be superseded or the historical billing charge identity.

Added Sufficit.Sales.LegacyRenewalSnapshot, serialized under reserved contract parameter
migration.legacy_renewal_snapshot_v1. Captures the selected latest source row's code/service GUID,
customer, exact start/end/billing and source-update timestamps, nullable value/commission,
commissioned identity and renewed flag. Date precision and source Kind are preserved; no implicit
conversion based on the development host timezone is introduced.

Import comparison now includes this snapshot. Reimport upgrades existing records and refreshes
source evidence while retaining all other manager parameters. No new schema column is required.
This is migration evidence only, not an instruction to create a charge. The contract aggregate ID
must never be substituted for the old service ID when reconciling historical credit. A later writer
handoff must revalidate this snapshot against the source and fence legacy writes before proceeding.
Until then, the snapshot can be refreshed by import; it is not an immutable payment receipt.

Validation:19 ContractMigrationTests passed, including explicit different contract/source GUIDs,
commission preservation, subsecond source dates, old-import enrichment, operator parameter retention,
idempotent repetition and unchanged disabled automation. Log: workspace tmp/legacy-renewal-snapshot-tests.log.

No production import, deployment, credit, renewal event or authority switch was performed.
Still required: successor generation preserving legacy month-end/collision rules, stable operation
identity, commission carryover and durable existing telephony effects, followed by validated handoff.
Do not remove LegacySales automation guards merely because the snapshot is available.
