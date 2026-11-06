# Independent recurrence and settlement

Recurrence and posting time are independent. Catalog defaults use nullable recurrence/settlement fields; contract recurrence is snapshotted in audited parameter billing.recurrence.v1. Older callers preserve the saved snapshot. Catalog changes do not change existing contract recurrence. One-off tariffed credit validity does not create monthly purchases.

Validation: 110 EFData recurring, settlement, catalog and creation tests passed; client and preview builds passed; contract editor checked at 1440, 768 and 390 pixels. Additive schema migration must precede API rollout. No financial receipt or telephony configuration changed by source edits.

Final verification: 607 Sales tests passed (1 MySQL integration skipped), 115 Blazor tests passed, 213 API candidate-library tests passed. The full Sales suite caught and verified the fix for legacy compensation/transfer metadata preservation. API and Blazor installed and Healthy on all three apps hosts. API version 1.26.1106.1941, Blazor version 1.26.1106.1942. Additive catalog columns applied. Authenticated customer reconciliation is still blocked (401); existing customer projections were not repaired by direct SQL or by this rollout. Bound consumption resources retain their dedicated workflows.
