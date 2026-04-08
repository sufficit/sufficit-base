using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System;
using Sufficit;

namespace Sufficit.Telephony.InterConnection.PJSIP
{
    /// <summary>
    ///     Realtime domain alias row used by Asterisk to accept requests for additional local SIP domains.
    /// </summary>
    public class PJSIPDomainAlias : ITimestamp
    {
        [JsonPropertyName("id")]
        public virtual string id { get; set; } = default!;

        [JsonIgnore]
        public DateTime CreatedAtUtc { get; set; }

        [JsonIgnore]
        public DateTime? UpdatedAtUtc { get; set; }

        [JsonIgnore]
        public DateTime? DeletedAtUtc { get; set; }

        [JsonPropertyName("domain")]
        [Column("domain")]
        public virtual string? domain { get; set; }
    }
}
