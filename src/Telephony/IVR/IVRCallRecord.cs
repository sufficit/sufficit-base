using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.IVR
{
    /// <summary>
    /// Snapshot of an IVRMenu call execution, suitable for logging and cross-application display.
    /// Stored as the content of a GenericLog entry in the logging system.
    /// </summary>
    public class IVRCallRecord
    {
        [JsonPropertyOrder(1)]
        public Guid IVRId { get; set; }

        [JsonPropertyOrder(2)]
        public string? IVRTitle { get; set; }

        [JsonPropertyOrder(3)]
        public Guid ContextId { get; set; }

        [JsonPropertyOrder(10)]
        public string? CallerId { get; set; }

        [JsonPropertyOrder(11)]
        public string? UniqueId { get; set; }

        [JsonPropertyOrder(12)]
        public string? Channel { get; set; }

        [JsonPropertyOrder(20)]
        public string? Phase { get; set; }

        [JsonPropertyOrder(21)]
        public string? Description { get; set; }

        [JsonPropertyOrder(30)]
        public string? LookupKey { get; set; }

        [JsonPropertyOrder(31)]
        public string? LookupType { get; set; }

        /// <summary>
        /// Digit or input the caller provided during this IVRMenu execution.
        /// </summary>
        [JsonPropertyOrder(32)]
        public string? UserInput { get; set; }

        /// <summary>
        /// Asterisk destination chosen for this IVRMenu execution (e.g. "ext-queues,0000123456,1")
        /// </summary>
        [JsonPropertyOrder(40)]
        public string? ChosenDestination { get; set; }

        [JsonPropertyOrder(50)]
        public int TotalExecutionTimeMs { get; set; }
    }
}
