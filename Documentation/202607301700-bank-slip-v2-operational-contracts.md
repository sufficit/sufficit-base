# Bank slip V2 operational contracts

## Summary

The finance contracts now include tenant-aware bank slip search and compact
operational statistics. The contracts remain independent from HTTP, EF Core and
the provider gateways.

## Added contracts

- `BankSlipV2SearchParameters` and `BankSlipV2SearchResult`;
- `BankSlipV2StatisticsParameters`, `BankSlipV2Statistics` and
  `BankSlipV2ProviderStatistics`;
- `IBankSlipV2QueryProvider`;
- search and statistics methods on `IBankSlipV2Service`.
- a private public-document source contract, resolved only after tenant,
  context, bank slip, state and public-access checks.

The compact statistics contract is intended for administration surfaces. Raw
time-series data stays in the configured metrics backend and Grafana.
