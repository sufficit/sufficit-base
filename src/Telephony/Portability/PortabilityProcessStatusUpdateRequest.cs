using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Portability
{
    public class PortabilityProcessStatusUpdateRequest
    {
        /// <summary>
        ///     Unique process id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PortabilityProcessStatus Status { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
