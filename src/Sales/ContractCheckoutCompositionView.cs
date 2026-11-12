#if NET10_0_OR_GREATER
using System;
using System.Collections.Generic;
using Sufficit.Gateway;
namespace Sufficit.Sales;
public sealed record ContractCheckoutCompositionView(Guid SessionId, long AmountCents,
    IReadOnlyList<ServiceCheckoutDetail> Details, IReadOnlyList<BillingChargeItemView>? Items = null, string? ServiceDisplayName = null, int? PreferredPaymentMethod = null, IReadOnlyList<int>? AllowedPaymentMethods = null);


#endif
