using System;
using System.Text.Json;

namespace Sufficit.Finance
{
    /// <summary>
    /// Represents the safe authenticated view of a bank slip v2 resource.
    /// </summary>
    public class BankSlipV2View
    {
        public Guid Id { get; set; }
        public Guid ContextId { get; set; }
        public decimal Value { get; set; }
        public string Currency { get; set; } = "BRL";
        public decimal IssuanceCost { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public BankSlipStatus Status { get; set; }
        public string Provider { get; set; } = string.Empty;
        public string ProviderSelection { get; set; } = string.Empty;
        public string? BarCode { get; set; }
        public string? ErrorCategory { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorName { get; set; }
        public string? ErrorTitle { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ErrorAction { get; set; }
        public bool CanRetry { get; set; }
        public bool PublicAccessEnabled { get; set; }
        /// <summary>
        /// Gets the provider-hosted HTML payment page for authenticated operators.
        /// </summary>
        public string? ProviderHtmlUrl { get; set; }

        /// <summary>
        /// Gets the internal public capability URL that streams the PDF.
        /// </summary>
        public string? DocumentUrl { get; set; }
        public JsonElement? Attributes { get; set; }
        public long Version { get; set; }
    }
}
