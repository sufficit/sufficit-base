using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Represents the provider-independent data required to issue a bank slip.
    /// </summary>
    public class BankSlipGatewayIssueRequest
    {
        public Guid BankSlipId { get; set; }
        public Guid ContextId { get; set; }
        public string? ProviderChargeId { get; set; }
        public decimal Value { get; set; }
        public DateTime Expiration { get; set; }
        public string Description { get; set; } = string.Empty;
        public Uri? NotificationUrl { get; set; }
        /// <summary>
        /// When set, explicitly controls whether the payer e-mail may be included
        /// in the provider payload. A null value lets the gateway use its default.
        /// </summary>
        public bool? IncludePayerEmail { get; set; }
        public BankSlipPayerSnapshot Payer { get; set; } = default!;
    }
}
