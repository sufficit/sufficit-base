using System;

namespace Sufficit.Events
{
    /// <summary>
    /// Base interface for all events
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Gets the timestamp indicating when the event occurred.
        /// </summary>
        DateTime Timestamp { get; }

		/// <summary>
		/// Gets a unique identifier for the event.
		/// </summary>
		Guid EventId { get; }

        /// <summary>
        /// Gets the type of the event represented by this instance.
        /// </summary>
        string EventType { get; }
    }
}