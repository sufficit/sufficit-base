# Commercial transfer request

Added Sufficit.Sales.ContractTransferRequest with transfer/retry GUID, source contract GUID, source/destination customer GUIDs, observed update timestamp and required reason. The endpoint obtains actor and effective UTC instant from server context. Catalog GUID identity is retained; a new contract GUID preserves ownership of source financial history.

Consumed by the manager API, Standard facade and EFData transaction. Base compiled for net10 and netstandard2.0. Behavior/limits and validation: sufficit-efdata/Documentation/202610011600-immediate-contract-transfer.md. No database schema changes or deployment in this checkpoint.
