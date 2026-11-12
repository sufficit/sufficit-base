#if NET10_0_OR_GREATER
using System;
using System.Collections.Generic;

namespace Sufficit.Sales;

public sealed record ContractCheckoutToggleRequest(Guid ContractId, bool Enabled);

public sealed record ContractCheckoutChargeView(
    Guid Id, Guid PeriodId, DateTime DueDate, decimal Amount, string Status,
    DateTime? ConfirmedReceiptUtc);

public sealed record ContractCheckoutLinkView(
    Guid ContractId, bool Enabled, string? Url,
    IReadOnlyList<ContractCheckoutChargeView> Charges);

public sealed record ContractCheckoutResolveView(
    string Status, string ServiceTitle, string? CheckoutUrl,
    decimal? Amount, DateTime? DueDate, DateTime? NextDueDate);

public sealed record ContractCheckoutPayerView(string Name, string Document, string Email);

#endif
