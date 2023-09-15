using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Asterisk.PJSIP
{
    public class PJSIPContact
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = default!;

        /// <summary>
        ///     SIP URI to contact peer
        /// </summary>
        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        /// <summary>
        ///     Time to keep alive a contact
        /// </summary>
        [JsonPropertyName("expiration_time")]
        [Column("expiration_time")]
        public uint? ExpirationTime { get; set; }

        /// <summary>
        ///     Interval at which to qualify a contact
        /// </summary>
        [JsonPropertyName("qualify_frequency")]
        [Column("qualify_frequency")]
        public int? QualifyFrequency { get; set; }

        /// <summary>
        ///     Timeout for qualify
        /// </summary>
        [JsonPropertyName("qualify_timeout")]
        [Column("qualify_timeout")]
        public float? QualifyTimeout { get; set; }

        /// <summary>
        ///     Authenticates a qualify challenge response if needed
        /// </summary>
        [JsonPropertyName("authenticate_qualify")]
        [Column("authenticate_qualify")]
        public string? AuthenticateQualify { get; set; }

        /// <summary>
        ///     Outbound proxy used when sending OPTIONS request
        /// </summary>
        [JsonPropertyName("outbound_proxy")]
        [Column("outbound_proxy")]
        public string? OutboundProxy { get; set; }

        /// <summary>
        ///     Stored Path vector for use in Route headers on outgoing requests
        /// </summary>
        [JsonPropertyName("path")]
        public string? Path { get; set; }

        /// <summary>
        ///     User-Agent header from registration
        /// </summary>
        [JsonPropertyName("user_agent")]
        [Column("user_agent")]
        public string? UserAgent { get; set; }

        /// <summary>
        ///     Endpoint name
        /// </summary>
        [JsonPropertyName("endpoint")]
        public string? Endpoint { get; set; }

        /// <summary>
        ///     Asterisk Server name
        /// </summary>
        [JsonPropertyName("reg_server")]
        [Column("reg_server")]
        public string? RegServer { get; set; }

        /// <summary>
        ///     IP-address of the last Via header from registration
        /// </summary>
        [JsonPropertyName("via_addr")]
        [Column("via_addr")]
        public string? ViaAddr { get; set; }

        /// <summary>
        ///     IP-port of the last Via header from registration
        /// </summary>
        [JsonPropertyName("via_port")]
        [Column("via_port")]
        public int? ViaPort { get; set; }

        /// <summary>
        ///     Call-ID header from registration
        /// </summary>
        [JsonPropertyName("call_id")]
        [Column("call_id")]
        public string? CallId { get; set; }

        /// <summary>
        ///     A contact that cannot survive a restart/boot
        /// </summary>
        [JsonPropertyName("prune_on_boot")]
        [Column("prune_on_boot")]
        public string? PruneOnBoot { get; set; }
    }
}
