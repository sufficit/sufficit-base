using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Portability
{
    /// <summary>
    /// Note associated with a portability process
    /// Provides timestamped notes with public/private visibility control
    /// Primary Key: (ProcessId, Timestamp)
    /// </summary>
    public class PortabilityNote
    {
        /// <summary>
        /// Reference to the portability process
        /// Foreign key to PortabilityProcess.Id
        /// Part of composite primary key
        /// </summary>
        [JsonPropertyName("processid")]
        public Guid ProcessId { get; set; }

        /// <summary>
        /// Timestamp when the note was created
        /// Part of composite primary key
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Note text content
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; } = default!;

        /// <summary>
        /// Indicates if this note is publicly visible
        /// true = visible to clients
        /// false = internal only (visible to staff only)
        /// </summary>
        [JsonPropertyName("public")]
        public bool Public { get; set; }

        /// <summary>
        /// User ID who created the note (required for audit)
        /// </summary>
        [JsonPropertyName("userid")]
        public Guid UserId { get; set; }
    }
}
