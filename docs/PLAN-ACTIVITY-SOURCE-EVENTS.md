# Activity creation from source events

Objective: expose an authenticated source-event boundary that opens independent collaborator work once, preserving immutable receipts and later operator edits.

1. COMPLETED — Define and validate a source request contract and its stable command mapping in Base.
2. IN PROGRESS — Wire the administrator-only API and authenticated Client; verify exact replay, changed replay, actor/context isolation and retention against the relational store.
3. PENDING — Publish verified packages/API and record installed evidence.

Scope: explicit OperationalActivityRequested events. Do not infer task creation from every commercial change, replay the historical integration backlog, invent an automation actor, or send production reminders. Generic automatic module event mappings and durable reminder dispatch remain pending in operational queue checkpoint 3; queue UI remains checkpoint 4. This delivery creates no activity during deployment.

English identifiers and inline documentation; future UI localized with pt-BR fallback. No schema changes are needed: reuse activity command receipts and context-scoped origin keys.

Base contract builds on netstandard2.0, net7.0 and net10.0 with zero errors. Source-event mapping always creates Open revision zero work and records source occurrence in immutable receipt reason. API/relational verification is next.
