using System;
using System.Text.RegularExpressions;

namespace Sufficit.Telephony
{
    public static class VoiceMailDirectNumber
    {
        // Existing internal dialing supports three to five digits. IVR and service
        // entrypoints intercept these reserved values before local resolution.
        public static bool IsValid(string? value) => value != null
            && Regex.IsMatch(value, @"\A[0-9]{3,5}\z")
            && !(value.Length == 4 && value.StartsWith("70", StringComparison.Ordinal))
            && value != "8001";

        public static string? Normalize(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            value = value.Trim();
            if (!IsValid(value))
                throw new ArgumentException("Use an available internal number with 3 to 5 digits; 70XX and 8001 are reserved.", nameof(value));
            return value;
        }
    }
}
