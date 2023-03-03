using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.DIDs
{
    public class ContextUpdateParameters
    {
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        /// <summary>
        /// Clearing extra informations
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Clear { get; set; } = false;

        /// <summary>
        /// Service expiration, used for isolete item for a period 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? Expire { get; set; }
    }
}
