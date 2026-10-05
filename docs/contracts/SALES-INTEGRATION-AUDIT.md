# Sales integration audit

## Ownership and existing transport

Sales owns Contract, ContractHistory and the append-only sals_integration_events outbox. CustomerContractCoverageChanged is already schema v1; its Version is a customer stream version, not a contract revision. SalesCoverageEventCapture writes inside the aggregate transaction. SalesCoverageDelivery records one delivery per subscriber/event, leases, retry attempts and immutable audit. The API SalesCoverageDeliveryWorker uses telephony-coverage-v1; receiver storage and technical provisioning are different stages.

Finance owns payments, receipts and financial effects. Commercial FinancialOperations record intent, not proof of receipt. Telephony owns provisioning and carrier state. Activities and temporal financial responsibility will be implemented as separate modules.

## First read contract

GET /Sales/IntegrationAudit requires an authenticated administrator and a nonempty contextId. afterVersion is an exclusive stream cursor (default 0); limit is 1–100 (default 50). correlationId optionally narrows results within that context. Rows are ordered by streamVersion ascending; nextVersion is populated only when another page exists. Preserve context and correlation filters while paging. A null nextVersion is end-of-page evidence at the time of the read, not proof that no future event can arrive.

DTOs expose event identity/type/time/correlation/stream version and subscriber transport state, attempt count, lease expiration and retry availability. No event payload, source parameters, actor inferred from another table, exception text or credentials are exported. Missing delivery means no recorded attempt; absence of rows does not prove capture enabled or synchronization complete. Per-subscriber deliveryStatus stored means durably received, not provisioned. Events and delivery state are read without locking or claims; delivery may change between the two queries.

No schema changes, event capture activation, new broker, retry command or production mutation is introduced. Deployment and role-scoped UI are separate pending delivery steps.

## Runtime inventory (2026-10-05)

Effective configuration on EVEO/APOINT/CASTRUM API: ContractHistoryCaptureEnabled=true. IntegrationEventCaptureEnabled, ProjectionCaptureEnabled and CoverageDelivery.Enabled are absent, therefore disabled by existing defaults. Contract audit capture is active; this does not prove event delivery. Do not present an empty event page as fully synchronized. Activation requires source schema, baseline and consumer checks and was not performed in this delivery.
