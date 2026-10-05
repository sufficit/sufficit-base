# Sales record customer identity

`SalesRecord` describes a customer's commercial service or credit allocation record. It is not a catalog definition or a fiscal invoice.

## Customer fields

| C# property | API JSON field | Meaning |
| --- | --- | --- |
| `ContextId` | `contextId` | Current customer context identifier (UUID). Used for ownership and authorization. |
| `LegacyCustomerCode` | `legacyCustomerCode` | Optional unsigned 32-bit numeric customer reference retained for historical traceability. |

The public property `Cliente` and JSON field `cliente`/`Cliente` have been removed from this DTO. No alias is emitted or mapped. Consumers must send and read `legacyCustomerCode`. This is an API contract change; persisted historical records and their stored field names have not been renamed.

The record appears in responses from `POST /Sales/Record/Search` and in the service payloads of `/Sales/LegacyService`. API metadata is generated from the DTO, whose `JsonPropertyName` attribute explicitly fixes the new field spelling.

Example payload fragment (illustrative):

```json
{
  "contextId": "11111111-1111-4111-8111-111111111111",
  "legacyCustomerCode": 42
}
```

`legacyCustomerCode` can be `null`; it never replaces `contextId` in permission checks. Clients using the old CLR DTO or property require recompilation. Publish Base, EFData, Standard and their consuming hosts together with the preceding `SalesRecord` type rename.
