using Sufficit.EndPoints;
using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Notification
{
    public class ContactValidationResponse : EndPointResponse
    {
        [JsonPropertyName("channel"), JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TChannel Channel { get; set; }

        [JsonPropertyName("destination"), JsonPropertyOrder(2)]
        public string Destination { get; set; } = default!;

        /// <summary>
        ///     Valid destination, threated and normalized
        /// </summary>
        [JsonPropertyName("valid"), JsonPropertyOrder(3)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Valid { get; set; }
    }
}
