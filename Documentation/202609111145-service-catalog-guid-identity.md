# Service catalog identity contract

`ServiceCatalogItem.Id` is the stable GUID identity for the service type. `Name` is an editable, required human-readable label, not a natural key. Two definitions may have the same name but must have different IDs. Creation with an empty Id generates a GUID in the provider; update/select/delete target the existing GUID.

The catalog-level `Code` property has been removed. This is a source/binary contract change: consumers that previously accessed Code must be rebuilt together (EFData, Standard, Client, Endpoints and Blazor). JSON no longer exposes a catalog Code field. Do not substitute the name as an identity or generate another code from the GUID.

Contract.CatalogItemId and parameter/tax/cost CatalogItemId relationships remain unchanged. Renaming a definition must not change any GUID or its links. Existing contract titles and prices remain historical snapshots; this change does not rewrite them.

Fiscal/tax codes and contract parameter keys have separate domain semantics and are unaffected. This change only removes the service type's technical Code.

Database rollout must follow the [EFData procedure](../../sufficit-efdata/migrations/docs/Sales/202609111145-service-catalog-guid-identity.md); publishing new binaries against the old NOT NULL code column would prevent inserts. No production deployment/schema change was performed in this task.
