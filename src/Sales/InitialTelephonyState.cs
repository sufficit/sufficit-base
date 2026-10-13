using System;
namespace Sufficit.Sales;

/// <summary>Read-only initial activation facts; commercial coverage and operational preparation are independent.</summary>
public sealed class InitialTelephonyState
{
    public string? CustomerTitle { get; set; }
    public Guid ContextId { get; set; }
    public Guid? CurrentNativeContractId { get; set; }
    public bool HasCurrentService { get; set; }
    public DateTime? FirstFutureStart { get; set; }
    public bool TelephonyPrepared { get; set; }
}
