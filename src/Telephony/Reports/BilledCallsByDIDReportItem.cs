using Sufficit.Telefonia.Asterisk;
using Sufficit.Telefonia.Classifier;
using Sufficit.Telephony.Asterisk;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony.Reports
{
    public class BilledCallsByDIDReportItem
    {
        [JsonPropertyOrder(0)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid Id { get; set; }

        [JsonPropertyOrder(0)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ContextId { get; set; }

        [JsonPropertyOrder(0)]
        public string Extension { get; set; } = default!;

        [JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint Days { get; set; }

        [JsonPropertyOrder(1)]
        public uint Count { get; set; }

        [JsonPropertyOrder(1)]
        public uint Seconds { get; set; }

        [JsonPropertyOrder(1)]
        public decimal Amount { get; set; }

        /// <summary>
        ///     There is pending billed calls, not processed yet by billing service
        /// </summary>
#if !DEBUG
        [JsonIgnore]
#else
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
#endif
        [JsonPropertyName("pending")]
        [JsonPropertyOrder(2)]
        public HashSet<AsteriskCallDetailsRecord>? Pending { get; set; }

#if !DEBUG
    [JsonIgnore]
#endif
        [JsonPropertyOrder(3)]
        public HashSet<CallBillingRecord> Records { get; set; } = new HashSet<CallBillingRecord>();
    }

    public class BilledCallsByDIDReportSubItem
    {
        public CallBilling Billing { get; set; }

        public string Extension { get; set; } = default!;

        public uint Days { get; set; }

        public uint Count { get; set; }

        public decimal Amount { get; set; }
    }
}
