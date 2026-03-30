using System.Text.Json.Serialization;

namespace Sufficit.Sales.Events
{
    /// <summary>
    ///     Canonical sales-to-telephony event for prepaid coverage, balance, or validity changes.
    /// </summary>
    public sealed class TelephonyServiceCoverageChangedEvent : TelephonyServiceContractEventBase, ITelephonyServiceCoverageEvent
    {
        /// <summary>
        ///     Stable event type name for event bus transport and persistence.
        /// </summary>
        public const string EVENTTYPE = "sales_contract_telephony_coverage_changed";

        /// <summary>
        ///     Event type identifier.
        /// </summary>
        [JsonPropertyName("type")]
        public override string Type => EVENTTYPE;

        /// <summary>
        ///     Specific coverage transition represented by this event.
        /// </summary>
        [JsonPropertyName("change_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TelephonyServiceCoverageChangeType ChangeType { get; set; }

        /// <summary>
        ///     Coverage amount granted or removed by the event.
        /// </summary>
        [JsonPropertyName("coverage_amount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? CoverageAmount { get; set; }

        /// <summary>
        ///     Remaining available balance or coverage after the event was applied.
        /// </summary>
        [JsonPropertyName("available_amount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? AvailableAmount { get; set; }

        /// <summary>
        ///     Unit associated with the coverage values, such as BRL, minute, or credit.
        /// </summary>
        [JsonPropertyName("coverage_unit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CoverageUnit { get; set; }
    }
}
