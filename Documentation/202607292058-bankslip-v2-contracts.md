# Bank slip v2 shared contracts

## Scope

The parallel bank slip module persists provider-independent state in MySQL and must not expose Efí or Asaas status codes to application consumers. The shared enums added under `Sufficit.Finance` define the stable vocabulary used by persistence, workers, gateways and the `/v2` API.

## Contracts

- `BankSlipStatus` defines the aggregate lifecycle.
- `BankSlipProviderSelection` records whether the provider came from tenant defaults or an explicit request.
- `BankSlipProviderEnvironment` separates sandbox from production configuration.
- `BankSlipOperation` and `BankSlipAttemptOutcome` classify external calls.
- `BankSlipErrorCategory` implements the conservative error taxonomy approved for retries and reconciliation.
- `BankSlipProviderCodes` defines the persisted codes `efi` and `asaas`; the legacy name Gerencianet is not persisted by the new module.
- `IBankSlipGateway` defines create, query and cancel operations without provider-specific payloads.
- `IBankSlipCredentialResolver` keeps secrets outside bank slip, job and outbox records.
- `BankSlipGatewayException` carries only a sanitized code, stable category, HTTP status and optional external charge identifier.

Provider-specific statuses and errors must be translated at the gateway boundary. Unknown external outcomes must be classified as `AmbiguousResult` until reconciliation proves otherwise.
