using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.Zabbix
{
    /// <summary>
    /// Search contract for persisted Zabbix alert executions.
    /// Used by the monitoring API and Blazor UI to list recent executions for one integration or context.
    /// </summary>
    public class ZabbixAlertExecutionSearchParameters : ILimit
    {
        /// <summary>
        /// Optional direct filter by the public alert identifier.
        /// Maps to <see cref="ZabbixAlertExecution.Id"/>.
        /// </summary>
        [JsonPropertyName("alert_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? AlertId { get; set; }

        /// <summary>
        /// Optional tenant context filter.
        /// Used by the monitor page to keep history scoped to the currently selected context.
        /// </summary>
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }

        /// <summary>
        /// Optional integration filter.
        /// This is the main filter used by the Blazor monitor for the selected integration.
        /// </summary>
        [JsonPropertyName("integration_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? IntegrationId { get; set; }

        /// <summary>
        /// Optional execution status filter.
        /// Allows future screens to focus on failures, running items or suppressed alerts.
        /// </summary>
        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public ZabbixAlertExecutionStatus? Status { get; set; }

        /// <summary>
        /// Maximum number of execution rows returned.
        /// The provider applies this after ordering by most recent start time first.
        /// </summary>
        [JsonPropertyName("limit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public uint? Limit { get; set; }
    }
}