using Sufficit.Events;
using System;
using System.Text.Json.Serialization;

namespace Sufficit.Sales.Events
{
    /// <summary>
    ///     Base payload for sales events that synchronize telephony state without coupling the modules through shared tables.
    /// </summary>
    public abstract class TelephonyServiceContractEventBase : EventBase, ITelephonyServiceContractEvent
    {
        /// <summary>
        ///     UTC timestamp when the event was created.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public override DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        ///     Tenant or customer context identifier.
        /// </summary>
        [JsonPropertyName("context_id")]
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Recurring contract identifier.
        /// </summary>
        [JsonPropertyName("contract_id")]
        public Guid ContractId { get; set; }

        /// <summary>
        ///     Related billing period identifier when applicable.
        /// </summary>
        [JsonPropertyName("period_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? PeriodId { get; set; }

        /// <summary>
        ///     Related interruption identifier when applicable.
        /// </summary>
        [JsonPropertyName("interruption_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? InterruptionId { get; set; }

        /// <summary>
        ///     External service key or commercial reference.
        /// </summary>
        [JsonPropertyName("contract_key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ContractKey { get; set; }

        /// <summary>
        ///     Friendly contract title.
        /// </summary>
        [JsonPropertyName("contract_title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ContractTitle { get; set; }

        /// <summary>
        ///     Current contract status.
        /// </summary>
        [JsonPropertyName("contract_status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContractStatus ContractStatus { get; set; }

        /// <summary>
        ///     UTC effective start date for the operational change represented by this event.
        /// </summary>
        [JsonPropertyName("effective_from_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? EffectiveFromUtc { get; set; }

        /// <summary>
        ///     UTC effective end date for the operational change represented by this event.
        /// </summary>
        [JsonPropertyName("effective_until_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? EffectiveUntilUtc { get; set; }

        /// <summary>
        ///     UTC expiration date relevant to telephony enablement or coverage control.
        /// </summary>
        [JsonPropertyName("expires_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ExpiresAtUtc { get; set; }

        /// <summary>
        ///     UTC due date for the related billing period when available.
        /// </summary>
        [JsonPropertyName("due_date_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? DueDateUtc { get; set; }

        /// <summary>
        ///     UTC next due date for the recurring contract when available.
        /// </summary>
        [JsonPropertyName("next_due_date_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? NextDueDateUtc { get; set; }

        /// <summary>
        ///     Human-readable reason for the event.
        /// </summary>
        [JsonPropertyName("reason")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Reason { get; set; }
    }
}
