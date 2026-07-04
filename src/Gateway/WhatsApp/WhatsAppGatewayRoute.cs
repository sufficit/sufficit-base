using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.WhatsApp
{
    public class WhatsAppGatewayRoute : ITimestamp
    {
        /// <summary>
        /// Primary key. For WhatsApp Official (Meta Cloud API) this is the dialed phone number
        /// digits (matches the dialplan's routing key). For Quepasa it's the session identifier
        /// in "phone:index" form, since multiple sessions can share the same phone number.
        /// </summary>
        [JsonPropertyName("sessionid")]
        public string SessionId { get; set; } = string.Empty;

        /// <summary>
        /// Tenant/context this route belongs to. Used for authorization and listing routes per client.
        /// </summary>
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Whether inbound calls should be routed. Disabled routes are kept (not deleted) so
        /// they can be re-enabled without reconfiguring the destination.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Optional id of the Sufficit destination (extension/queue/IVR) resolved via
        /// <see cref="DestinationAsterisk"/>. Informational; the dialplan only uses
        /// <see cref="DestinationAsterisk"/> to route the call.
        /// </summary>
        [JsonPropertyName("destinationid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? DestinationId { get; set; }

        /// <summary>
        /// Asterisk dialplan target the call is sent to (e.g. "sufficit-app-ivr,123,1").
        /// This is the value actually used by the FastAGI script to route the call.
        /// </summary>
        [JsonPropertyName("destinationasterisk")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? DestinationAsterisk { get; set; }

        /// <summary>
        /// Human-readable label for the destination type (e.g. "IVRMenu", "FreePBXDirectCall"),
        /// used for display only.
        /// </summary>
        [JsonPropertyName("destinationtype")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? DestinationType { get; set; }

        /// <summary>
        /// Provider auth token, when applicable. Persisted but currently not read by any
        /// downstream consumer (FastAGI resolves routing without it).
        /// </summary>
        [JsonPropertyName("token")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Token { get; set; }

        /// <summary>
        /// E.164 phone number (always "+"-prefixed on save, enforced centrally by
        /// EFWhatsAppGatewayProvider.Normalize). Display only; not used for routing.
        /// </summary>
        [JsonPropertyName("phone")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Phone { get; set; }

        /// <summary>
        /// "exclusive" or "parallel". Whether this number/session is dedicated to this
        /// integration alone (WhatsApp Official always is) or shares the line with other
        /// call handling (Quepasa's typical case).
        /// </summary>
        [JsonPropertyName("mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Mode { get; set; }

        /// <summary>
        /// How simultaneous/competing calls on the same line are handled (e.g. forward/ignore/deny/allow).
        /// </summary>
        [JsonPropertyName("callmode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? CallMode { get; set; }

        /// <summary>
        /// Any notes that facilitate identification on searches.
        /// </summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Description { get; set; }

        /// <summary>
        /// Regex to restrict allowed source caller ids before routing the call.
        /// </summary>
        [JsonPropertyName("filter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Filter { get; set; }

        /// <summary>
        /// Tags or caller id name prefixes used by the telephony routing layer.
        /// </summary>
        [JsonPropertyName("tags")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Tags { get; set; }

        /// <summary>
        /// Maximum simultaneous channels allowed for this route. Enforced via Asterisk GROUP_COUNT.
        /// </summary>
        [JsonPropertyName("maxchannels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public int? MaxChannels { get; set; }

        /// <summary>
        /// Raw JSON snapshot of the request that created/updated this route, kept for auditing.
        /// </summary>
        [JsonPropertyName("payloadjson")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? PayloadJson { get; set; }

        [JsonPropertyName("created_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime CreatedAtUtc { get; set; }

        [JsonPropertyName("updated_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? UpdatedAtUtc { get; set; }

        /// <summary>
        /// Soft-delete marker. Rows are tombstoned (kept, timestamped) rather than removed,
        /// so incremental sync consumers can observe the deletion.
        /// </summary>
        [JsonPropertyName("deleted_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? DeletedAtUtc { get; set; }

        [JsonPropertyName("updatedby")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? UpdatedBy { get; set; }
    }
}
