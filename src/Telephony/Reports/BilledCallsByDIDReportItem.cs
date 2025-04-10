using Sufficit.Telephony;
using Sufficit.Telephony.Asterisk;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ProviderId { get; set; }

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
        public IEnumerable<AsteriskCallDetailsRecord>? Pending { get; set; }

#if !DEBUG
    [JsonIgnore]
#endif
        [JsonPropertyOrder(3)]
        public IEnumerable<CallBillingRecord> Records { get; set; } = default!;
    }
}
