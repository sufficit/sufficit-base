using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Reports
{
    /// <summary>
    /// Uso tarifado de chamadas agrupado pelo ramal que iniciou ou atendeu a chamada.
    /// </summary>
    public class UsageByExtensionReportItem
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
        public string Extension { get; set; } = string.Empty;

        [JsonPropertyOrder(1)]
        public uint InboundCount { get; set; }

        [JsonPropertyOrder(1)]
        public uint OutboundCount { get; set; }

        [JsonPropertyOrder(1)]
        public decimal InboundMinutes { get; set; }

        [JsonPropertyOrder(1)]
        public decimal OutboundMinutes { get; set; }

        [JsonPropertyOrder(1)]
        public decimal InboundAmount { get; set; }

        [JsonPropertyOrder(1)]
        public decimal OutboundAmount { get; set; }

        /// <summary>
        ///     Calls between internal extensions, never counted as inbound or outbound
        /// </summary>
        [JsonPropertyOrder(1)]
        public uint InternalCount { get; set; }

        [JsonPropertyOrder(1)]
        public decimal InternalMinutes { get; set; }

        [JsonPropertyOrder(1)]
        public decimal InternalAmount { get; set; }
    }
}
