using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// EndPoint Extension
    /// </summary>
    public class EndPoint
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; } = default!;

        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("userid")]
        public Guid? UserId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("recording")]
        public bool Recording { get; set; }

        /// <summary>
        /// Interval for qualify endpoint, in milliseconds
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("qualify")]
        public uint? Qualify { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("forwarding")]
        public bool? Forwarding { get; set; }

        /// <summary>
        /// Disallow codecs
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("disallow")]
        public string? Disallow { get; set; }

        /// <summary>
        /// Allowed codecs
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("allow")]
        public string? Allow { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("outboundcid")]
        public string? OutboundCID { get; set; }

        /// <summary>
        ///     Last updated time
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }


        [JsonPropertyName("pending")]
        public bool Pending { get; set; }

        [JsonPropertyName("tech_sip")]
        public bool TechSIP { get; set; }

        [JsonPropertyName("tech_pjsip")]
        public bool TechPJSIP { get; set; }

        [JsonPropertyName("tech_iax")]
        public bool TechIAX { get; set; }
    }
}
