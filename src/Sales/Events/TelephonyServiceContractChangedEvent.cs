using System.Text.Json.Serialization;

namespace Sufficit.Sales.Events
{
    /// <summary>
    ///     Canonical sales-to-telephony event for recurring service lifecycle and period state changes.
    /// </summary>
    public sealed class TelephonyServiceContractChangedEvent : TelephonyServiceContractEventBase
    {
        /// <summary>
        ///     Stable event type name for event bus transport and persistence.
        /// </summary>
        public const string EVENTTYPE = "sales_contract_telephony_changed";

        /// <summary>
        ///     Event type identifier.
        /// </summary>
        [JsonPropertyName("type")]
        public override string Type => EVENTTYPE;

        /// <summary>
        ///     Specific lifecycle transition represented by this event.
        /// </summary>
        [JsonPropertyName("change_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TelephonyServiceContractChangeType ChangeType { get; set; }

        /// <summary>
        ///     Indicates whether telephony should consider the service operationally enabled after this change.
        /// </summary>
        [JsonPropertyName("service_enabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ServiceEnabled { get; set; }

        /// <summary>
        ///     Indicates whether outbound telephony should remain allowed after this change.
        /// </summary>
        [JsonPropertyName("outbound_enabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? OutboundEnabled { get; set; }

        /// <summary>
        ///     Final billable amount of the related period when the event refers to a closed or recalculated period.
        /// </summary>
        [JsonPropertyName("billable_amount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? BillableAmount { get; set; }
    }
}
