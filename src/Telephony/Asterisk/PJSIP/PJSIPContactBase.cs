using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Asterisk.PJSIP
{
    public class PJSIPContactBase
    {
        /// <summary>
        ///     SIP URI to contact peer
        /// </summary>
        [JsonPropertyName("uri")]
        public string? uri { get; set; }

        /// <summary>
        ///     Time to keep alive a contact
        /// </summary>
        [JsonPropertyName("expiration_time")]
        [Column("expiration_time")]
        public uint? expiration_time { get; set; }

        /// <summary>
        ///     Interval at which to qualify a contact
        /// </summary>
        [JsonPropertyName("qualify_frequency")]
        [Column("qualify_frequency")]
        public int? qualify_frequency { get; set; }

        /// <summary>
        ///     Timeout for qualify
        /// </summary>
        [JsonPropertyName("qualify_timeout")]
        [Column("qualify_timeout")]
        public float? qualify_timeout { get; set; }

        /// <summary>
        ///     Authenticates a qualify challenge response if needed
        /// </summary>
        [JsonPropertyName("authenticate_qualify")]
        [Column("authenticate_qualify")]
        public string? authenticate_qualify { get; set; }

        /// <summary>
        ///     Outbound proxy used when sending OPTIONS request
        /// </summary>
        [JsonPropertyName("outbound_proxy")]
        [Column("outbound_proxy")]
        public string? outbound_proxy { get; set; }

        /// <summary>
        ///     Stored Path vector for use in Route headers on outgoing requests
        /// </summary>
        [JsonPropertyName("path")]
        public string? path { get; set; }

        /// <summary>
        ///     User-Agent header from registration
        /// </summary>
        [JsonPropertyName("user_agent")]
        [Column("user_agent")]
        public string? user_agent { get; set; }

        /// <summary>
        ///     Endpoint name
        /// </summary>
        [JsonPropertyName("endpoint")]
        public string? endpoint { get; set; }

        /// <summary>
        ///     Asterisk Server name
        /// </summary>
        [JsonPropertyName("reg_server")]
        [Column("reg_server")]
        public string? reg_server { get; set; }

        /// <summary>
        ///     IP-address of the last Via header from registration
        /// </summary>
        [JsonPropertyName("via_addr")]
        [Column("via_addr")]
        public string? via_addr { get; set; }

        /// <summary>
        ///     IP-port of the last Via header from registration
        /// </summary>
        [JsonPropertyName("via_port")]
        [Column("via_port")]
        public int? via_port { get; set; }

        /// <summary>
        ///     Call-ID header from registration
        /// </summary>
        [JsonPropertyName("call_id")]
        [Column("call_id")]
        public string? call_id { get; set; }

        /// <summary>
        ///     A contact that cannot survive a restart/boot
        /// </summary>
        [JsonPropertyName("prune_on_boot")]
        [Column("prune_on_boot")]
        public string? prune_on_boot { get; set; }
    }
}
