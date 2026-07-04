using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Filters for querying <see cref="WhatsAppGatewayRoute"/>, including the incremental
    /// (updated/deleted-since) sync fields used by the FastAGI runtime store.
    /// </summary>
    public class WhatsAppGatewayRouteSearchParameters : IIncrementalTrackingSearchParameters
    {
        /// <summary>
        /// Exact match on the route's session id (primary key).
        /// </summary>
        [JsonPropertyName("sessionid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? SessionId { get; set; }

        /// <summary>
        /// Filter by tenant/context.
        /// </summary>
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }

        /// <summary>
        /// Filter by enabled/disabled state.
        /// </summary>
        [JsonPropertyName("enabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Filter by resolved destination id.
        /// </summary>
        [JsonPropertyName("destinationid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? DestinationId { get; set; }

        /// <summary>
        /// When set, filters to soft-deleted (true) or active (false) routes.
        /// </summary>
        [JsonPropertyName("deleted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Deleted { get; set; }

        /// <summary>
        /// Incremental sync window (updated/deleted since a watermark), used by the FastAGI
        /// runtime store to refresh its in-memory snapshot without a full reload.
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TimestampFilter? Timestamp { get; set; }
    }
}
