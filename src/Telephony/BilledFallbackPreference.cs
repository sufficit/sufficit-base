using System;

namespace Sufficit.Telephony
{
    /// <summary>Customer preference for the implicit prepaid outbound fallback.</summary>
    public class BilledFallbackPreference
    {
        public const string PropertyKey = "outbound-billed-fallback";
        public Guid ContextId { get; set; }
        public bool Enabled { get; set; } = true;

        public static bool IsEnabled(string? value)
            => value == null || (bool.TryParse(value, out var enabled) && enabled);
    }
}
