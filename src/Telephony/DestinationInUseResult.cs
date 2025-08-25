using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Represents a single usage result for a destination in a specific context
    /// </summary>
    public class DestinationInUseResult : Destination
    {
        /// <summary>
        /// Context description of the usage (e.g., "Queue: Sales", "IVR: Main Menu, Option: 1")
        /// </summary>
        [JsonPropertyOrder(3)]
        public string? Usage { get; set; }
    }
}
