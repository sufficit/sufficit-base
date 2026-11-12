#if NET10_0_OR_GREATER
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Sales;

public sealed record CustomerPaymentPreference(Guid ContextId, [property: JsonIgnore(Condition = JsonIgnoreCondition.Never)] uint? DueDay);
public sealed class CustomerPaymentPreferenceChange
{
    [JsonRequired, Range(1, 31)] public uint? DueDay { get; set; }
    [JsonRequired, Range(1, 31)] public uint? ExpectedDueDay { get; set; }
}
public interface ICustomerPaymentPreferences
{
    Task<CustomerPaymentPreference> Get(Guid contextId, CancellationToken ct);
    Task<CustomerPaymentPreference> Set(Guid contextId, CustomerPaymentPreferenceChange change, Guid actor, CancellationToken ct);
}

#endif
