# DID collection policy evaluator — 2026-10-01 17:08 BRT

## Confirmed business rules
Fixed/mobile contact means the same collection message was delivered AND read (email, WhatsApp or other supported channel). Three days run from confirmed reading. Delivery alone does not qualify. Toll-free blocks at due+3 regardless of contact or call balance. Final review is due+90 days. With blocking confirmed, final notice is recorded; fixed/mobile include portability instructions. No fixed unlink deadline: remind the manager every7days. Local quarantine ends at original due+6 calendar months, counting time already elapsed. Supplier-managed quarantine uses a cancellation request to the supplier, never a locally invented release deadline.

## Implementation
Base introduces DidCollectionPolicy, DidCollectionKind, DidCollectionCase and DidCollectionEvaluation under Sufficit.Finance, one type per file. Policy includes version and bounded timing settings. Standard DidCollectionEvaluator is deterministic, synchronous and side-effect-free. Result reports recommendations and next reminder time; it has no DB, network, route, credit or unlink operation.

Caller must correlate delivery/read evidence to the same message, customer, DID and overdue cycle. Future/non-UTC evidence is rejected; incomplete contact is not assumed. Fixed/mobile reading predating this overdue cycle is not used. Date arithmetic overflow fails instead of producing a cut recommendation. If no actual block is confirmed at90days, result requests review rather than inventing a block or overriding the contact grace. Recorded final notice is required for unlink/supplier-cancellation review. Seven-day reminder scheduling uses the last recorded reminder, or initial final notice; callers must persist successful reminder delivery and deduplicate execution.

Settlement/unlink stops recommendations and never restores routes automatically. A passed quarantine horizon never automatically frees the DID. WhatsApp collection policy remains explicitly unsupported because no separate rule was specified. Toll-free no longer inherits fixed/mobile contact gating.

The earlier ContractInboundProjectionPreview expiry suggestion is restricted to toll-free: fixed/mobile now return null without verified contact. This supersedes the generic +3 suggestion introduced earlier.

## Validation
26 tests passed: collection evaluator plus inbound preview. Calendar-month case Aug31->Feb28, exact D+3/D+90/weekly boundaries, stale/incomplete/future contact evidence, settlement, supplier quarantine and unchanged input state covered. Standard netstandard2.0 build passed with zero errors/31 existing warnings. Logs: tmp/did-collection-final-tests.log and did-collection-netstandard.log. Diff checks clean.

## Limits
Local library implementation only. No deployment, notification, block, cancellation, quarantine mutation or manager reminder was performed. Persistence of cases/policy versions/evidence/decisions, delivery/read adapters, scheduler with idempotent receipts, provider cancellation confirmation and manager UI remain pending. These are required before this becomes an operational collection system. Existing migration plan remains open; MSSQL is not retired.
