using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Notification
{
    public class ContactValidationRequest
    {
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = default!;

        [JsonPropertyName("channel")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TChannel Channel { get; set; }
    }
}
