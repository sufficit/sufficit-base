# Tariffed trunk date comparison refinement

## Decision
TRONCO TARIFADO represents a balance top-up that may happen whenever credit runs out. Its start day is not a fixed monthly cycle. The canonical Sales constant identifies this category, ignoring label case and outer whitespace. No cycle assumptions were added for other categories.

## Changes
Base suggestion policy excludes these rows before grouping customer days/counts. Source coverage and truncation still use every inspected row. Blazor uses the same policy for optional day indicators and the day summary, retains all historical rows and the explicit correction editor, and labels top-ups as having no fixed day. Read-only screen AI follows the same interpretation. No API DTO, persisted record, spreadsheet or production customer data was changed.

## Validation
Four new regression cases failed before the change; all 15 focused tests passed afterward. The actual Blazor project and synthetic preview compiled with zero errors (existing warnings). The task worktree used an absolute local UI ProjectReference only during validation because the dependency symlink produced CS0006; the original project file was restored afterward and no validation override is included in the change. Synthetic browser checks passed at 1280/800/390 pixels: a June20 top-up stays visible and editable while the day comparison stays 6/8; drill-down, reviewed correction, receipt and preserved unrelated query parameters remain functional. Production was not exercised or mutated.

## Delivery
Isolated task worktrees only. Integration/publication awaits explicit approval for this refinement under Blazor TASK-GUARDRAIL-20260323. Published Base package availability and API/Blazor package floors must be confirmed during delivery. No installation or production behavior is claimed for this refinement.
