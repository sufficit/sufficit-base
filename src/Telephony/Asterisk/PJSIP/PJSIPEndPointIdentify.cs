using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Asterisk.PJSIP
{
    /// <summary>
    ///     Realtime identify row used by Asterisk to bind inbound traffic to one endpoint.
    /// </summary>
    public class PJSIPEndPointIdentify
    {
        [JsonPropertyName("id")]
        public virtual string id { get; set; } = default!;

        [JsonPropertyName("endpoint")]
        [Column("endpoint")]
        public virtual string? endpoint { get; set; }

        [JsonPropertyName("match")]
        [Column("match")]
        public virtual string? match { get; set; }

        [JsonPropertyName("srv_lookups")]
        [Column("srv_lookups")]
        public virtual string? srv_lookups { get; set; }

        [JsonPropertyName("match_header")]
        [Column("match_header")]
        public virtual string? match_header { get; set; }
    }
}
