using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>UTC, half-open validity interval shared by grants and routes.</summary>
    public static class OutboundValidity
    {
        public static bool IsValidInterval(DateTime? startUtc, DateTime? expirationUtc)
            => startUtc.HasValue && expirationUtc.HasValue
                && startUtc.Value.Kind == DateTimeKind.Utc
                && expirationUtc.Value.Kind == DateTimeKind.Utc
                && expirationUtc.Value > startUtc.Value;

        public static bool Contains(DateTime? startUtc, DateTime? expirationUtc, DateTime utcNow)
        {
            if (utcNow.Kind != DateTimeKind.Utc)
                throw new ArgumentException("UTC clock required", nameof(utcNow));

            return IsValidInterval(startUtc, expirationUtc)
                && startUtc!.Value <= utcNow
                && utcNow < expirationUtc!.Value;
        }

        public static DateTime? EarliestExpiration(params DateTime?[] expirations)
        {
            if (expirations == null || expirations.Length == 0)
                return null;

            DateTime? earliest = null;
            foreach (var value in expirations)
            {
                if (!value.HasValue || value.Value.Kind != DateTimeKind.Utc)
                    return null;
                if (!earliest.HasValue || value.Value < earliest.Value)
                    earliest = value;
            }
            return earliest;
        }
    }
}
