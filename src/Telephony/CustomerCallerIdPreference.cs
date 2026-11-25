using System;

namespace Sufficit.Telephony
{
    /// <summary>Customer default outbound presentation number. Null restores automatic selection.</summary>
    public sealed class CustomerCallerIdPreference
    {
        public const string PropertyKey = "outbound-caller-id";
        public Guid ContextId { get; set; }
        public string? Number { get; set; }
    }
}
