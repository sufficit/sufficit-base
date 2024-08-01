using Sufficit.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange
{
    /// <summary>
    ///     Used to log details of messages, metadata
    /// </summary>
    public class MessageDetails : LogBaseServerAndTime
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }

        [JsonPropertyName("referenceid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ReferenceId { get; set; }

        [JsonPropertyName("modelid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ModelId { get; set; }

        [JsonPropertyName("recipient")]
        public string Recipient { get; set; } = default!;

        [JsonPropertyName("channel")]
        public TChannel Channel { get; set; } = default!;

        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Status { get; set; }

        [JsonPropertyName("exception")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public JsonException? Exception { get; set; }
    }
}
