using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    /// <summary>
    /// Filters the operational view of recently received payments.
    /// </summary>
    public sealed class RecentPaymentSearchParameters : ILimit
    {
        /// <summary>Inclusive UTC start of the period. Defaults to three days ago.</summary>
        public DateTime? Start { get; set; }

        /// <summary>Inclusive UTC end of the period. Defaults to the end of today.</summary>
        public DateTime? End { get; set; }

        /// <summary>Minimum payment value included in the result.</summary>
        [DefaultValue(typeof(decimal), "0")]
        public decimal MinimumValue { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        [JsonPropertyName("limit")]
        [DefaultValue((uint)250)]
        public uint? Limit { get; set; } = 250;

        [DefaultValue(true)]
        public bool IncludeBankSlip { get; set; } = true;

        [DefaultValue(true)]
        public bool IncludeCard { get; set; } = true;

        [DefaultValue(true)]
        public bool IncludeMercadoPago { get; set; } = true;
    }
}
