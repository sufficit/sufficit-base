# Independent recurrence and settlement

Recurrence and posting time are independent. Catalog defaults use nullable recurrence/settlement fields; contract recurrence is snapshotted in audited parameter billing.recurrence.v1. Older callers preserve the saved snapshot. Catalog changes do not change existing contract recurrence. One-off tariffed credit validity does not create monthly purchases.

Validation: 110 EFData recurring, settlement, catalog and creation tests passed; client and preview builds passed; contract editor checked at 1440, 768 and 390 pixels. Additive schema migration must precede API rollout. No financial receipt or telephony configuration changed by source edits.
