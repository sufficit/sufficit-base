# Automatic customer suggestions for service date review

## Requested outcome
The manager enters the review screen without choosing a customer. The API suggests customers whose records in the reviewed month have different Brazilian civil start days. Suggestions are review candidates, not automatic corrections or a definitive correct day.

## Implementation
- Shared typed result and deterministic grouping policy in Base; no writes.
- Manager-only API query with current commercial authority and explicit global BalanceView entitlement. Source is bounded to 500 monthly records and reports partial coverage. Titles are resolved through one bounded contact stream under existing visibility rules, not one browser call per customer.
- Typed Client transport; Blazor landing lists customer names, observed days, record counts and a direct comparison action. Month is preserved in the URL; unrelated query parameters survive. Entry does not adopt the global selected customer.
- Existing individual correction/revision/retry workflow remains unchanged. Read-only AI exposes the visible suggestions and coverage only.

## Validation
Ten focused tests passed, including grouping by customer, Brazilian date conversion, aligned customers omitted, no source mutation and explicit truncated coverage. API Release and Blazor server Release builds passed with zero errors; existing warnings remain. Real-page synthetic browser fixture passed automatic suggestions, customer drill-down, comparison/review/receipt and no-overflow checks at 1280, 800 and 390 pixels. Initial suggestion screenshot at 800 pixels was visually inspected. No production data or spreadsheet was changed.

## Delivery gate
Sources and review commits are isolated in feature worktrees; these are not deployment staging copies. Original branches and unrelated local documentation remain preserved. New task-commit integration requires explicit per-action approval under sufficit-blazor/AGENTS.md TASK-GUARDRAIL-20260323. Once authorized, integrate/publish Base first, then raise Client minimum to that confirmed package version before Client publication; application source dependencies must resolve that contract. Deploy through original repository deploy.py scripts, not worktree copies. This suggestion update has not been installed in production.

## Limitations
Suggestions currently cover different start days within the selected month, not every spreadsheet discrepancy. Hitting 500 records gives a partial list. A single service or several services with the same wrong day cannot be detected by this rule. Existing receipt/read inconsistency for the earlier June correction is a separate observed backend issue.
