# FastAGI DialOut Usage Shared Models

## About
Move the shared operational DialOut usage payloads from `sufficit-fastagi-service` local projects into `Sufficit.Base` so both the FastAGI host and the FastAGI HTTP client reuse the same contracts.

## Why
Both projects already depend on `Sufficit.Base`. Keeping `DialOutUsageSnapshot` and `DialOutUsageResetResponse` duplicated in the service and in the client created unnecessary maintenance overhead and drift risk.

## Changes
- Added `src/Telephony/Outbound/DialOutUsageSnapshot.cs`
- Added `src/Telephony/Outbound/DialOutUsageResetResponse.cs`
- Kept the shared namespace as `Sufficit.Telephony.Outbound`
- Updated the FastAGI service to consume the shared contracts instead of local `src/DialOut/Models/*`
- Updated the FastAGI client to consume the same shared contracts instead of local duplicates
- Removed duplicated model files from:
  - `sufficit-fastagi-service/src/DialOut/Models/`
  - `sufficit-fastagi-service/client/src/`

## Scope
This change only affects shared DTO placement and references. It does not change endpoint routes, payload shapes, controller behavior, or reset semantics.

## Affected repositories
- `sufficit-base`
- `sufficit-fastagi-service`

## Shared contracts
- `Sufficit.Telephony.Outbound.DialOutUsageSnapshot`
- `Sufficit.Telephony.Outbound.DialOutUsageResetResponse`

## Follow-up
- Rebuild `sufficit-base`
- Rebuild `sufficit-fastagi-service` host
- Rebuild `sufficit-fastagi-service/client`
- Rebuild any consumer already referencing the new shared client package/project
