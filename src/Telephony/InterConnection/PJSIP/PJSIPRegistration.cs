using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System;
using Sufficit;

namespace Sufficit.Telephony.InterConnection.PJSIP
{
    /// <summary>
    ///     Realtime outbound registration row used by Asterisk to maintain remote SIP registrations.
    /// </summary>
    public class PJSIPRegistration : ITimestamp
    {
        [JsonPropertyName("id")]
        public virtual string id { get; set; } = default!;

        [JsonIgnore]
        public DateTime CreatedAtUtc { get; set; }

        [JsonIgnore]
        public DateTime? UpdatedAtUtc { get; set; }

        [JsonIgnore]
        public DateTime? DeletedAtUtc { get; set; }

        /// <summary>
        ///     Logical VoIP server tag used by Sufficit to scope registrations per node.
        ///     This value is used internally for MySQL convergence and is not sent back to Asterisk CURL.
        /// </summary>
        [JsonPropertyName("server")]
        [Column("server")]
        public virtual string? server { get; set; }

        [JsonPropertyName("transport")]
        [Column("transport")]
        public virtual string? transport { get; set; }

        [JsonPropertyName("outbound_auth")]
        [Column("outbound_auth")]
        public virtual string? outbound_auth { get; set; }

        [JsonPropertyName("server_uri")]
        [Column("server_uri")]
        public virtual string? server_uri { get; set; }

        [JsonPropertyName("client_uri")]
        [Column("client_uri")]
        public virtual string? client_uri { get; set; }

        [JsonPropertyName("contact_user")]
        [Column("contact_user")]
        public virtual string? contact_user { get; set; }

        [JsonPropertyName("expiration")]
        [Column("expiration")]
        public virtual int? expiration { get; set; }

        [JsonPropertyName("retry_interval")]
        [Column("retry_interval")]
        public virtual int? retry_interval { get; set; }

        [JsonPropertyName("forbidden_retry_interval")]
        [Column("forbidden_retry_interval")]
        public virtual int? forbidden_retry_interval { get; set; }

        [JsonPropertyName("fatal_retry_interval")]
        [Column("fatal_retry_interval")]
        public virtual int? fatal_retry_interval { get; set; }

        [JsonPropertyName("max_retries")]
        [Column("max_retries")]
        public virtual int? max_retries { get; set; }

        [JsonPropertyName("auth_rejection_permanent")]
        [Column("auth_rejection_permanent")]
        public virtual string? auth_rejection_permanent { get; set; }

        [JsonPropertyName("line")]
        [Column("line")]
        public virtual string? line { get; set; }

        [JsonPropertyName("endpoint")]
        [Column("endpoint")]
        public virtual string? endpoint { get; set; }

        [JsonPropertyName("support_path")]
        [Column("support_path")]
        public virtual string? support_path { get; set; }

        [JsonPropertyName("outbound_proxy")]
        [Column("outbound_proxy")]
        public virtual string? outbound_proxy { get; set; }

        [JsonPropertyName("security_negotiation")]
        [Column("security_negotiation")]
        public virtual string? security_negotiation { get; set; }

        [JsonPropertyName("security_mechanisms")]
        [Column("security_mechanisms")]
        public virtual string? security_mechanisms { get; set; }
    }
}
