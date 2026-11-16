# GUID-addressed protocol applications

Scope: Native ProtocolApplication contract and canonical IDestination address.

1. Completed — implement the contract described in the coordinated plan, preserving current application IDs and tenants.
2. Completed — required Release builds, focused regression/gates and main commit/push.
3. In progress — validated deployment/migration where applicable, delivery record and completed-plan conversion.

Coordinated execution and acceptance: [protocol application plan](../../sufficit-pabx-asterisk/docs/PLAN-PROTOCOL-GUID-APPLICATION.md). No new Blazor screen is requested.

Compatibility validation: Standard netstandard2.0 and node API net7.0 Release compile passed after adding the native provider to the frozen Web profile and aligning node Microsoft.Extensions 8.x dependencies. Full net10 node suite: 100 passed; EF Telephony: 214 passed; required API security/voice group: 264 passed; commercial audit: 139 passed. Candidate artifact tests remain part of deployment.
