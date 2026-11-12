#if NET10_0_OR_GREATER
using System;
using System.Collections.Generic;
using Sufficit.Gateway;
namespace Sufficit.Sales;
public sealed class BillingOverviewRow
{
    public Guid Id { get; set; }
    public Guid ContextId { get; set; }
    public Guid? ContractId { get; set; }
    public string? CustomerTitle { get; set; }
    public string Title { get; set; } = "Cobrança";
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
    public decimal PaidAmount { get; set; }
    public string Status { get; set; } = "";
    public string Kind { get; set; } = "recurring";
    public bool Simulation { get; set; }
}
public sealed record BillingOverviewPage(IReadOnlyList<BillingOverviewRow> Items, int? NextOffset, string Coverage);


#endif
