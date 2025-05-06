using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Portability
{
    public class PortabilityProcessFileMap
    {
        /// <summary>
        ///     Unique Portability process id
        /// </summary>
        [JsonPropertyName("portabilityid")]
        public Guid PortabilityId { get; set; }

        /// <summary>
        ///     Unique Storage object id
        /// </summary>
        [JsonPropertyName("objectid")]
        public Guid ObjectId { get; set; }
    }
}
