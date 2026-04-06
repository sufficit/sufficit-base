using System;

namespace Sufficit.Telephony.CallDispatch
{
    /// <summary>
    /// Stores an optional persisted preset for Call Dispatch internal Asterisk routing.
    /// The runtime flow accepts either this preset id or the destination directly in the request.
    /// </summary>
    public class CallDispatchConfiguration
    {
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        public string Asterisk { get; set; } = default!;

        public DateTime Timestamp { get; set; }
    }
}