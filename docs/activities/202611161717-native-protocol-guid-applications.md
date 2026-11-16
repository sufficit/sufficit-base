# GUID-addressed protocol applications

Scope: Native ProtocolApplication contract and canonical IDestination address.

1. Completed — implement the contract described in the coordinated plan, preserving current application IDs and tenants.
2. Completed — required Release builds, focused regression/gates and main commit/push.
3. Completed — validated deployment/migration where applicable, delivery record and completed-plan conversion.

Coordinated execution and acceptance: [protocol application plan](../../../sufficit-pabx-asterisk/docs/activities/202611161717-native-protocol-guid-applications.md). No new Blazor screen is requested.

Compatibility validation: Standard netstandard2.0 and node API net7.0 Release compile passed after adding the native provider to the frozen Web profile and aligning node Microsoft.Extensions 8.x dependencies. Full net10 node suite: 100 passed; EF Telephony: 214 passed; required API security/voice group: 264 passed; commercial audit: 139 passed. Candidate runtime validation passed: 264 tests and zero missing custom assembly references.

## Verified delivery
Production migration completed on 2026-11-16. The 24 application IDs and owners are preserved; their downstream destinations are native configuration. The reported customer has four native instances. SQL readback confirmed all 21 changed routing records, no old protocol custom wrappers and no remaining inventoried old references. Six condition fallbacks were reconciled, generated wrappers were removed, and post-apply node previews have no pending writes. All three voice nodes have the canonical GUID dialplan and warm memory snapshots; all three management API nodes match the tested binary hashes and report Healthy.

Web publication: [workflow 43945498713](https://github.com/sufficit/sufficit-web/actions/runs/43945498713), success, eveo-web only; installed appsettings preserved. Source references: Base f9891ad, EFData 56b29cd, Standard 6c286b1, EndPoints 95a393a, node API cbacb37/978d07a, PABX 604b0b2, Web 4fbcb37e. Later unrelated source commits are outside this artifact; parallel work was preserved. Local publication artifacts were removed after confirmed promotion. Root-only migration/runtime journals and original runtime backups remain on the servers.

Evidence: focused authorization/provider/destination/store tests, 100 node API tests, 214 Telephony provider tests, 264 candidate security/voice/billing tests, 139 commercial audit tests, netstandard2.0/net7.0/net10.0 build coverage and 8 GUID Asterisk cases. Read-only installed-library probe confirms 25 catalog records with 6 explicit modality links in 3 product groups and four customer protocol applications. Loaded IVR and time-condition probes confirm native protocol IDs without an external call. No new Blazor screen or human audio acceptance was included; the separate media acceptance plan remains pending.
