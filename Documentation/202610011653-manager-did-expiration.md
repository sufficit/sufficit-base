# Manager-owned DID expiration command — 2026-10-01 16:53 BRT

## Contract
POST /Telephony/DID/Expiration is restricted to Manager or Administrator. Input DIDExpirationUpdateParameters carries Id, ExpectedContextId, ExpectedExpiration, Expiration (nullable, UTC), and a required 3–500-character Reason. Use the current operational DID read for the expected values. Expiration=null explicitly clears the expiry. The manager reviews the previously implemented service-end-plus-three-days suggestion; this endpoint does not query Sales or calculate/consume commercial entitlements.

EFData UpdateExpiration performs one conditional relational UPDATE of Expire only. The predicate matches DID ID, expected context and nullable previous expiration. Zero matching rows return HTTP409, requiring reload. Invalid identity/reason/UTC date returns HTTP400. Success returns204. No AddOrUpdate, Context(), destination conversion, PABX reload, owner change or financial action. The existing Context endpoint is intentionally not reused: it changes destinations to Isolated/HangUp.

API uses existing Track infrastructure with customer context, DID reference, before/after dates and reason, retention10years. Audit tracking follows existing application behavior and is not claimed to be atomic with the database write. SDK exposes APIClient.Telephony.DID.Expiration(parameters, token). No Blazor UI was added in this checkpoint.

## Validation
- Two EFData tests passed on SQLite relational fixture: exact field preservation, null expiry, stale date, wrong context, and invalid command before database access.
- One API authorization metadata test passed, API/net10 compiled.
- EFData net7 supported target compiled, zero errors/16warnings.
- Client net10 compiled, zero errors/26warnings.
- An attempted forced EFData netstandard build failed NU1015 because EFData currently declares only net7/net10; followed with its actual net7 target successfully. No dependency versions were changed to fabricate a target.
- Diff-check clean. No production mutation/deployment/call test performed. Local code only.

## Jobs checked
TableCleanUpJob invokes named retention providers; FreePBX CleanUp only clears cached AdminInformations and returns0. AutoCleanUpJob dynamically discovers ICleanUp implementations: its actual runtime registration still requires inventory. Searches found no direct route-checkup/reload calls in Background jobs. SCTelefonia.Recarregar still invokes ClienteVerificarServicos when explicitly called; its automatic commercial caller was removed in the previous checkpoint. This limited source scan does not certify every deployed host or all dynamic jobs.

Remaining: manager screen integration, audit of runtime jobs, publication to appropriate hosts, coordinated remaining MSSQL consumer cutover. MSSQL remains active.
