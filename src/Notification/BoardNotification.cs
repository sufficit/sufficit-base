using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Notification
{
    public class BoardNotification
    {
        [JsonPropertyName("ruleid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid RuleId { get; set; }

        /// <summary>
        ///     For distributions purpouses, used to distinguish who can view
        /// </summary>
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Model id for a message, used to identify different types of views or areas for messages
        /// </summary>
        [JsonPropertyName("modelid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual Guid ModelId { get; set; }

        /// <summary>
        ///     Object reference id, used to specify a target context item
        /// </summary>
        [JsonPropertyName("referenceid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ReferenceId { get; set; }

        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual string Message { get; set; } = default!;

        /// <summary>
        ///     Link to action or help
        /// </summary>
        [JsonPropertyName("helplink")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? HelpLink { get; set; }

        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }
    }
}
