#if NET10_0_OR_GREATER
using System;
using System.Collections.Generic;
using Sufficit.Gateway;
namespace Sufficit.Sales;
public sealed record ContractRecurringQuote(Guid SessionId, Guid ContractId, string PermanentLink,
    decimal Amount, DateTime DueDate, string Title, bool CanAuthorize = true, decimal? MonthlyAmount = null, DateTime? MonthlyDueDate = null, bool TestPayment = false);

#endif
