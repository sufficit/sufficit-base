# Service collection coverage, recipient portfolio and contact follow-up — 2026-10-09

## Source and scope
User authorized completion and publication of the management suggestions. User confirmed legacy day 18 means current service coverage ends on day 18: start the agenda on day 11. Financial invoice due dates are separate. Spreadsheet remains read-only. Late tolerance has no specified duration; no penalty, interest or automatic suspension is added.

## Implemented
- Current LegacyRenewalSnapshot provides period/service/context identity and coverage end; aggregate contract termination End is not used. Unknown/invalid sources remain review gaps. Balance top-ups remain excluded.
- Verified responsible-contact filtering applies in SQL before bounded pagination and retains beneficiary authorization and URL state.
- Dedicated Sales endpoints and reviewed UI record operator reports plus optional civil return date over the existing immutable Tasks journal. Actor, recipient revision, command identity and CAS are preserved; retry after a lost response returns the original receipt. This neither sends messages nor claims provider delivery or payment. Human manager permission is required on beneficiary and recipient.
- Contact editor has a single purpose; technical actor identity is available only in expandable audit details. Assistant integration exposes loaded state only.

## Evidence
- Standard policy tests: 21 passed (coverage 13, follow-up 8).
- Relational recipient pagination: 2 passed, including matching contracts beyond 200 unrelated rows and beneficiary isolation.
- OperationalActivityTests: 13 passed, 2 MariaDB-only skipped; explicit activity/context lookup tested.
- API and page preview builds: zero errors; existing warnings remain.
- Synthetic browser at 1280/800/390: coverage end 18 / collection start 11, future action guard, coverage expiry separate from invoice overdue, recipient URL filtering, response-loss retry, subsequent contact history and next-return display passed.
- No production spreadsheet, customer status, provider delivery or payment writes performed by tests.

## Delivery
Source is isolated from unrelated dirty original checkouts. New revision not yet installed when this record was written. Clean API CI has an optional manual publish_artifact input after validation; artifact installation uses the original repository official deployment module. Blazor main uses its existing clean deployment workflow. Final run IDs and installed versions belong in the publication record after verification.
Authenticated production tablet acceptance remains pending (previous CDP connection unavailable); synthetic viewport testing is not a production acceptance claim.
