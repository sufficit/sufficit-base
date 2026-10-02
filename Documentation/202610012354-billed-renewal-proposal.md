# Billed renewal proposal

Added LegacyBilledRenewal.Calculate separately from generic monthly renewal. It requires a stable
persisted UTC whole-second operation time, identified unrenewed predecessor and explicit source
timezone. Previous service ends one second before the successor starts. New expiration is six
calendar months from operation time; existing credit expiration is never mutated by this calculation.
A zero-value service produces no credit proposal. Invalid destination precision, negative/overflow
amounts, recent/future predecessor and subsecond operation timestamps fail explicitly.

This pure proposal generates no new GUID, does not authorize credit and performs no persistence.
The future operation receipt must freeze successor GUID and operation time in the same transaction;
never supply a fresh current time on retry. Historical import must never execute billed renewal.
Generic monthly persistence excludes billed catalogs and remains unchanged.

31 Standard tests passed covering billed/monthly calculations and migration. Included month-end
six-month validity, repeat stability, predecessor immutability, zero amount, decimal limits and
boundary rejection. Log: workspace tmp/legacy-billed-renewal-tests.log.

No production flags, schema, services, balances or jobs were changed. Billed persistence/delivery
and full cutover remain pending. The user's “continue” did not answer the pending inbound behavior
decision: preserve automatic assignment of an unowned DID (first queue or hangup fallback), or require
a manager action in the replacement. Existing operational behavior remains preserved meanwhile.
