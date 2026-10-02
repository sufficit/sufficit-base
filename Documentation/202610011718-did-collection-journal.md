# DID collection case journal — 2026-10-01 17:18 BRT

## Implemented
Append-only case revisions in MySQL `fina_did_collection_revisions`. Every revision includes operation ID, case ID, customer, monotonically increasing version, actor, UTC recording time and the exact JSON snapshot of policy, evidence and reason. No revision is overwritten or deleted by the provider. The unique case/version key arbitrates simultaneous saves. Operation replay succeeds only for the same serialized request and actor; conflicting reuse is rejected. Customer, DID, kind and overdue-cycle due date cannot be changed within a case. Changes to policy values require a new version label relative to the preceding revision.

API `Finance/DIDCollections` is restricted to Manager/Administrator:
- POST records a manager-attested snapshot, validating the evaluator first and requiring a real actor claim. This does not claim external delivery/read/block confirmation or perform the described operation.
- GET ?contextId=... lists latest revisions for up to100cases for that customer.
- GET /{caseId} returns latest revision; unknown case404.
- GET /{caseId}/History?afterVersion=0 returns up to100ascending revisions; advance the cursor for more.
- GET /{caseId}/Evaluation evaluates the latest recorded evidence without persisting or executing recommendations.

Request fields: CaseId, OperationId, ExpectedVersion (0 for first revision), Reason (3–500characters), Policy and Evidence. A stale version/conflicting operation produces409. Identity/reason/evaluator input failures produce400. A missing actor produces403. Caller must use the same operation ID and payload for retry and a new operation ID for a new revision. Evidence must be reviewed against the real customer/DID/cycle. No automatic provider adapter or actor impersonation is supplied.

## Validation
Relational SQLite test covers initial save, exact retry, changed actor/payload, stale version, identity mutation, policy-label conflict, unchanged historical evidence, latest-per-customer listing, incremental history and the database unique-version constraint. Two API tests cover manager/admin authorization and missing-actor refusal before database access. Three tests passed; API/net10 built; diff-check clean. Production MySQL DDL installed from migrations/sql/20261001_did_collection_revisions.sql and read back with primary/unique/customer-time indexes; zero rows after installation.

## Release
Published successfully to EVEO using official `python3 deploy.py eveo-apps --publish`. Service restarted at 17:21 BRT on 2026-10-01; post-deploy HTTPS health reports Healthy and version 1.26.1001.2018. All seven appsettings hashes are unchanged. Base, EFData, Standard and EndPoints assembly hashes match the published artifact. Anonymous access to Finance/DIDCollections returns HTTP 401. Pre-deploy rollback archive remains at /opt/sufficit-release-backups/collection-20261001-1717/endpoints-before.tar.gz. No messages or telephony actions sent; no collection case created for a real customer. This release covers EVEO EndPoints only; other consumers and MSSQL retirement remain pending.

## Remaining integrations
Manager screen, channel-specific evidence ingestion, persistent scheduler/notification receipts, actual supplier-cancellation adapters and operational approvals remain pending. Current snapshots are manager-attested, not automatically verified receipts. Case IDs are caller-managed; automatic case discovery must define stable cycle identity and deduplication before scheduling notifications. Policy snapshots/version labels are kept per case; a global policy registry is not implemented. List is capped at100cases (history has a cursor). MSSQL migration/cutover is still incomplete. No automatic blocking, unlinking or number release is registered.
