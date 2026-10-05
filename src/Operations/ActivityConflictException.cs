using System;

namespace Sufficit.Operations
{
    /// <summary>An expected revision, terminal state or idempotency conflict; not an infrastructure failure.</summary>
    public sealed class ActivityConflictException : InvalidOperationException
    {
        public ActivityConflictException(string message, Exception? inner = null) : base(message, inner) { }
    }
}
