using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Optional provider capability used by administrative reconciliation.
    /// It exposes a PII-free inventory and does not mutate provider resources.
    /// </summary>
    public interface IBankSlipProviderInventoryGateway
    {
        Task<ProviderBankSlipInventoryResult> GetInventoryAsync(
            ProviderBankSlipInventoryRequest request,
            BankSlipGatewayContext context,
            CancellationToken cancellationToken);
    }

    /// <summary>
    /// Provider-local calendar window used to enumerate issued bank slips.
    /// </summary>
    public sealed class ProviderBankSlipInventoryRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int MaximumItems { get; set; } = 2000;
    }

    /// <summary>
    /// PII-free provider inventory used only for operational comparison.
    /// </summary>
    public sealed class ProviderBankSlipInventoryResult
    {
        public IReadOnlyList<ProviderBankSlipInventoryItem> Items { get; set; }
            = Array.Empty<ProviderBankSlipInventoryItem>();
        public int RequestCount { get; set; }
        public bool Truncated { get; set; }
        /// <summary>
        /// Indicates that at least one page was loaded, but a later provider
        /// page could not be completed. Items already returned remain usable.
        /// </summary>
        public bool Partial { get; set; }
        public string? WarningCode { get; set; }
        public string? WarningMessage { get; set; }
    }

    /// <summary>
    /// One bank-slip fact returned by a provider inventory endpoint.
    /// </summary>
    public sealed class ProviderBankSlipInventoryItem
    {
        public string ChargeId { get; set; } = string.Empty;
        public string? CustomId { get; set; }
        public string ProviderStatus { get; set; } = string.Empty;
        public BankSlipStatus Status { get; set; }
        public decimal Value { get; set; }
        public DateTime? CreatedAtUtc { get; set; }
        public DateTime? PaidAtUtc { get; set; }
        public decimal? PaidValue { get; set; }
    }
}
