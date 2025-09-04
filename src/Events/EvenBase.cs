using System;
using System.Text.Json.Serialization;

namespace Sufficit.Events
{
    /// <summary>
    /// Base class for all events
    /// </summary>
    public class EventBase
    {
        /// <summary>
        /// Gets the timestamp indicating when the event occurred.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public virtual DateTime Timestamp { get; set; }

		/// <summary>
		/// Gets a unique identifier for the event.
		/// </summary>
        [JsonPropertyName("id")]
		public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Gets the type of the event represented by this instance.
        /// </summary>
        [JsonPropertyName("type")]
        public virtual string Type => GetType().Name;
    }
}