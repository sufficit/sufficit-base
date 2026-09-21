using System;

namespace Sufficit.Finance
{
    /// <summary>Optional interpretation of retained provider payment notices for read-only comparison.</summary>
    public interface IBankSlipPaymentEvidenceReader
    {
        BankSlipPaymentEvidence? ReadPaymentEvidence(string payload);
    }

    public sealed class BankSlipPaymentEvidence
    {
        public string ChargeId { get; set; } = string.Empty;
        public DateTime ReceivedAtUtc { get; set; }
        /// <summary>The original notice specifies a civil day, not a payment instant.</summary>
        public bool IsDateOnly { get; set; }
    }
}
