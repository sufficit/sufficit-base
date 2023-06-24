using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.Chatwoot
{
    public class CWCallBackRequest
    {
        /// <summary>
        /// Destination phone
        /// </summary>
        [Required]
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = default!;

        /// <summary>
        /// Used for sincronize with external applications
        /// </summary>
        [Required]
        [JsonPropertyName("externalid")]
        public string ExternalId { get; set; } = default!;

        /// <summary>
        /// Use identified outbound calls
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Identified { get; set; }

        /// <summary>
        /// Prepend a label on caller name to internal users
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Label { get; set; }

        /// <summary>
        /// Apply a delay before calling
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Delay { get; set; }
    }
}
