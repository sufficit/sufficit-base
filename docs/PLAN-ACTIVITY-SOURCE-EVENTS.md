# Activity creation from source events

Objective: expose an authenticated source-event boundary that opens independent collaborator work once, preserving immutable receipts and later operator edits.

1. COMPLETED — Define and validate a source request contract and its stable command mapping in Base.
2. COMPLETED — Wire the administrator-only API and authenticated Client; verify exact replay, changed replay, actor/context isolation and retention against the relational store.
3. COMPLETED — Publish verified packages/API and record installed evidence.

Scope: explicit OperationalActivityRequested events. Do not infer task creation from every commercial change, replay the historical integration backlog, invent an automation actor, or send production reminders. Generic automatic module event mappings and durable reminder dispatch remain pending in operational queue checkpoint 3; queue UI remains checkpoint 4. This delivery creates no activity during deployment.

English identifiers and inline documentation; future UI localized with pt-BR fallback. No schema changes are needed: reuse activity command receipts and context-scoped origin keys.

## Delivery evidence

- Base 4aa19d7: NuGet 1.26.1006.30; publication CI 37394280132 passed.
- Client cbccf84: NuGet 1.26.1006.36; publication CI 37394808573 passed. Exact packages downloaded and new DTO/method verified across all three targets.
- API 168cf89: clean CI 37394463944 passed build, 710 tests (zero skipped) and the TURN contract. Full local API suite also passed 710 tests; 16 focused relational scenarios and 2 Client transport scenarios passed.
- Official root deploy.py completed on eveo-apps, apoint-apps and castrum-apps. All health responses report Healthy, version 1.26.1006.0043 with source 168cf891ebb8c531cef30e50439b916823c75c5c. API/Base installed hashes match each publication folder; anonymous source-event POST returns 401 on every host.
- No production activity, reminder, financial entry or provisioning command was created for verification. No schema change. Authenticated end-user production acceptance is not claimed.

This bounded endpoint/package delivery is complete. Operational queue checkpoint 3 remains IN PROGRESS for explicit module mappings and reminder delivery; checkpoints 4 and 5 remain PENDING for UI, delegated grants, names, attachments and assistant. Financial responsibility integration remains PENDING.
