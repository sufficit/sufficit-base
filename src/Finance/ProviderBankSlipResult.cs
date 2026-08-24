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
        /// <summary>
        /// Client-defined identifier returned by the provider. Gateways use it
        /// to prove that a provider charge belongs to a canonical aggregate.
        /// </summary>
        public string? CustomId { get; set; }
        public string ProviderStatus { get; set; } = string.Empty;
        public BankSlipStatus Status { get; set; }
        /// <summary>
        /// Amount effectively settled by the payer when the provider exposes it.
        /// A paid status without this value must be reconciled conservatively.
        /// </summary>
        public decimal? SettledValue { get; set; }
        public DateTime? PaidAtUtc { get; set; }
        /// <summary>
        /// Boleto identification field (linha digitável) used for copy and paste.
        /// </summary>
        public string? IdentificationField { get; set; }
        /// <summary>
        /// Numeric boleto barcode payload intended for an Interleaved 2 of 5
        /// scanner presentation.
        /// </summary>
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
