using System;
using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    /// Represents a provider response translated into the stable bank slip domain.
    /// </summary>
    public class ProviderBankSlipResult
    {
        public string ProviderCode { get; set; } = string.Empty;
        public string ChargeId { get; set; } = string.Empty;
        public string ProviderStatus { get; set; } = string.Empty;
        public BankSlipStatus Status { get; set; }
        public string? BarCode { get; set; }
        /// <summary>
        /// Gets or sets the provider-hosted HTML payment page, when available.
        /// </summary>
        public Uri? HtmlUrl { get; set; }

        /// <summary>
        /// Gets or sets the provider-hosted bank slip PDF, when available.
        /// </summary>
        public Uri? PdfUrl { get; set; }

        /// <summary>
        /// Gets or sets the preferred legacy document URL.
        /// New integrations should populate <see cref="HtmlUrl"/> and
        /// <see cref="PdfUrl"/> independently.
        /// </summary>
        public Uri? Url { get; set; }
        public IReadOnlyDictionary<string, string>? Attributes { get; set; }
    }
}
