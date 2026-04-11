using System;

namespace Sufficit.Telephony.CallDispatch
{
    /// <summary>
    /// Stores an optional persisted preset for Call Dispatch internal Asterisk routing.
    /// The runtime flow accepts either this preset id or the destination directly in the request.
    /// </summary>
    public class CallDispatchConfiguration
    {
        /// <summary>
        /// Public identifier of the persisted preset.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Tenant context that owns this preset.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        /// Friendly operator-facing title used by management and selection UIs.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Internal Asterisk route used when this preset is selected at runtime.
        /// </summary>
        public string Asterisk { get; set; } = default!;

        /// <summary>
        /// Persistence version timestamp maintained by the database row.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}