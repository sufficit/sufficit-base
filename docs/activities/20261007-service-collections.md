# Daily service collection delivery — 2026-10-07

## Scope

Daily, authorized, bounded service collection portfolio with a default seven-calendar-day lead. Communication recipient is explicitly reviewed and does not change fiscal payer or service ownership. Prepaid automation reuses existing native resource bindings; no bulk opt-in, legacy inference, spreadsheet writes or production customer changes.

## Validation

- 17 policy tests passed: D-7, overdue, paid/unknown states, missing evidence, civil dates, tariffed top-ups and prepaid quote expiry.
- 33 prepaid/SQLite tests passed: existing paid-to-grant behavior, future coverage, authorization, immutable recipient receipts, exact replay after later changes, opt-in prerequisites, revision conflicts and preservation of an unsettled purchase basis.
- Release API and Blazor server builds passed; existing dependency/analyzer warnings remain.
- Real page with synthetic transport: Chromium at 1280, 800 and 390 pixels; recipient versus beneficiary, no mandatory customer selection, preserved URL parameters, reviewed recipient command, lost-response replay, session clearing and no horizontal overflow. Screenshots were visually inspected. Synthetic transport does not prove production portfolio reconciliation.

## Delivery boundaries

The SQL script creates communication profile and immutable journal tables. It was not applied to production. Integrate and publish dependency commits together; publish Base before consumers when packaging, updating package minimums to that actual published release as needed. Temporary absolute validation references were restored before commits. The multi-worktree browser fixture includes a local assembly resolver only for preview dependency collisions; production runtime resolution is unchanged.

Sending remains unconfirmed because the source does not track delivery. The screen displays nominal amount, never an invented partial-payment balance. Old quotes without persisted due date/expiry require review. Legacy services without financial links or prepaid resource bindings are explicit migration gaps.

## Pending operational gates

Specific integration approval required by TASK-GUARDRAIL-20260323; review/apply schema and publish through official root workflows after approval. Reconcile and validate a real pilot portfolio, including manager permissions and confirmed-payment coverage, before retiring its spreadsheet/sufficit-web daily workflow. The prior tariffed history refinement remains a separate prepared task.
