using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange.Templates
{
    /// <summary>
    /// Generic content structure for message templates that works with any message type
    /// </summary>
    public class MessageTemplateContent
    {
        /// <summary>
        /// Subject/title template with variable placeholders (used for email subject, notification title, etc.)
        /// </summary>
        [JsonPropertyName("subject")]
        [JsonPropertyOrder(0)]
        [StringLength(200)]
        public string? Subject { get; set; }

        /// <summary>
        /// Main content template with variable placeholders (email body, SMS text, notification message, etc.)
        /// </summary>
        [JsonPropertyName("body")]
        [JsonPropertyOrder(1)]
        [Required]
        public string Body { get; set; } = string.Empty;

        /// <summary>
        /// Additional properties for different message types (HTML content, attachments, etc.)
        /// </summary>
        [JsonPropertyName("properties")]
        [JsonPropertyOrder(2)]
        public Dictionary<string, object> Properties { get; set; } = new();
    }
}
