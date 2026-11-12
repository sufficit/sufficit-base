#if NET10_0_OR_GREATER
using System;
using System.Collections.Generic;
namespace Sufficit.Sales;
public sealed class BillingCommitmentServiceDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public decimal MonthlyAmount { get; set; }
}
public sealed class BillingCommitmentCustomerDto
{
    public Guid ContextId { get; set; }
    public string Title { get; set; } = "";
    public Guid PayerId { get; set; }
    public string PayerTitle { get; set; } = "";
    public DateTime? DueDate { get; set; }
    public decimal Commitment { get; set; }
    public decimal Balance { get; set; }
    public decimal Debt { get; set; }
    public decimal Amount { get; set; }
    public List<BillingCommitmentServiceDto> Services { get; set; } = new();
}
public sealed class BillingCommitmentPayerDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public int Customers { get; set; }
    public bool Representative { get; set; }
    public decimal Commitment { get; set; }
    public decimal Balance { get; set; }
    public decimal Debt { get; set; }
    public decimal Amount { get; set; }
}
public sealed class BillingCommitmentsDto
{
    public List<BillingCommitmentCustomerDto> Items { get; set; } = new();
    public List<BillingCommitmentPayerDto> Payers { get; set; } = new();
    public int TotalCustomers { get; set; }
    public int? NextOffset { get; set; }
    public decimal Commitment { get; set; }
    public decimal Debt { get; set; }
    public decimal Amount { get; set; }
    public DateTime AsOfUtc { get; set; }
}

#endif
