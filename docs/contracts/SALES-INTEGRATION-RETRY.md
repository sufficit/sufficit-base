# Audited sales integration retry

POST `Sales/IntegrationRetry` accepts `SalesIntegrationRetryRequest` and returns an immutable `SalesIntegrationRetryReceipt`. The existing administrative audit read includes the latest accepted request under `Deliveries[].LastRetry`. Older clients can ignore this additive optional field.

## Authorization and identity

Initially administrators only, matching the audit read boundary. The API requires authenticated administrator role and a nonempty user ID even when invoked directly. It derives the requester from authentication; the wire request has no requester field. Delegated context permissions remain a separate pending feature.

The request selects exactly one context, original event and supported subscriber (`telephony-coverage-v1`). It includes a caller-generated RequestId, observed ExpectedAttemptCount and a trimmed one-line reason of at most 512 characters. The caller retains RequestId after uncertain HTTP outcomes.

## State and idempotency

Only exhausted suspended deliveries without a lease are eligible. Stored, rejected, pending, busy and stale states produce conflict. Permanent rejection requires a separate reviewed correction; this command does not override it.

The lifetime AttemptCount is never reset. RetryCycleStart records its current value, granting one additional cycle of at most ten claims. A receipt and the state transition commit in the same serializable transaction. Identical replay by the same requester returns the same immutable receipt even after the transport state changes again; it never opens another cycle. Reusing RequestId for a different requester, context, event, subscriber, observed count or reason produces conflict.

The event ID, payload, stream version, original occurrence and correlation remain unchanged. The requester is distinct from any original business-operation actor, which is not invented when absent from the original envelope. Transport acceptance is not provisioning or financial completion.

## Rollout and rollback

Deploy the additive EFData migration `20261005_sales_event_retry.sql` before new API binaries. Keep `Sufficit:Sales:IntegrationRetryEnabled` absent or false until every source worker understands RetryCycleStart. Then enable the administrative command. Do not create real customer retries to verify deployment.

Before reverting to older worker binaries, disable the command and check for resumed cycles with RetryCycleStart > 0; older workers cannot honor their new budget. Preserve the schema and immutable receipts. Do not erase receipts or reset counters as a rollback.

## Stable HTTP outcomes

- 403: missing authentication, administrator role or requester identity.
- 503: `sales_integration_retry_disabled`.
- 400: `sales_integration_retry_invalid`.
- 409: `sales_integration_retry_conflict`.
- 200: the accepted immutable receipt.

The API does not return private exception text. Cancellation before commit leaves no accepted command.
