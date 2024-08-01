using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange.WhatsApp
{
    public class WhatsAppAttachment : MessageAttachment
    {
        /// <summary>
        ///     Time in seconds for audio/video messages
        /// </summary>
        [JsonPropertyName("seconds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public uint? Seconds { get; set; }

        [JsonPropertyName("filelength")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public ulong? FileLength { get; set; }

        [JsonPropertyName("base64")]
        public string Base64
        {
            get
            {
                if (Content != null)
                    return Convert.ToBase64String(Content);
                return string.Empty;
            }
            set
            {
                Content = Convert.FromBase64String(value);
            }
        }
    }
}
