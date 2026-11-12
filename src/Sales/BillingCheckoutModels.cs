#if NET10_0_OR_GREATER
using System;
using System.Collections.Generic;
using Sufficit.Sales;

namespace Sufficit.Sales;

public sealed record BillingCheckoutConfigure(Guid ContextId, Guid? ContractId, bool Enabled, int DueDay, bool RecurringCardEnabled, int? PreferredPaymentMethod = null, IReadOnlyList<int>? AllowedPaymentMethods = null);
public sealed record BillingChargeItemView(Guid ContractId, string Title, long AmountCents,
    DateTime PeriodStart, DateTime PeriodEnd, IReadOnlyList<ServiceCheckoutDetail> Details, bool IsProrated = false, bool IsAdvance = false);
public sealed record BillingChargeView(Guid Id, DateTime DueDate, decimal Amount, string Status,
    DateTime? ConfirmedReceiptUtc, IReadOnlyList<BillingChargeItemView> Items, bool Legacy = false, string? CheckoutUrl = null,
    decimal PaidAmount = 0, IReadOnlyList<ChargePaymentView>? Payments = null);
public sealed record ChargePaymentView(Guid Id, decimal Amount, int Method, string Status,
    DateTime CreatedAtUtc, DateTime? ConfirmedReceiptUtc);
public sealed record BillingCheckoutLinkView(Guid ContextId, Guid? ContractId, bool Enabled, int DueDay,
    bool RecurringCardEnabled, string? Url, IReadOnlyList<BillingChargeView> Charges, bool RecurringLocked = false, int? PreferredPaymentMethod = null, IReadOnlyList<int>? AllowedPaymentMethods = null, IReadOnlyList<int>? AvailablePaymentMethods = null, string? BankSlipUnavailableReason = null);

#endif
