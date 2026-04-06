using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Asterisk.PJSIP
{
    /// <summary>
    ///     Realtime domain alias row used by Asterisk to accept requests for additional local SIP domains.
    /// </summary>
    public class PJSIPDomainAlias
    {
        [JsonPropertyName("id")]
        public virtual string id { get; set; } = default!;

        [JsonPropertyName("domain")]
        [Column("domain")]
        public virtual string? domain { get; set; }
    }
}
