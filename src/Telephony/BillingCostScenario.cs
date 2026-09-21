using System;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     A common call and the cost the billing service applies to it for a context,
    ///     after merging the context's own costs with the system defaults
    /// </summary>
    public class BillingCostScenario
    {
        /// <summary>
        ///     What the call is, for people: "Saída para fixo, bina identificada"
        /// </summary>
        public string Title { get; set; } = string.Empty;

        public CallDirection Direction { get; set; }

        public BillingCostIdForward IdForward { get; set; }

        /// <summary>
        ///     Number used to resolve the cost, already in the E.164 form the billing service matches
        /// </summary>
        public string Sample { get; set; } = string.Empty;

        /// <summary>
        ///     Cost applied; null when nothing matches, so the call would not be rated
        /// </summary>
        public BillingCost? Cost { get; set; }
    }
}
