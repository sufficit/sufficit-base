using System;

namespace Sufficit.Sales
{
    /// <summary>Deterministic billed-service succession, separate from monthly invoicing.</summary>
    /// <remarks>A proposal never authorizes a credit. The caller must persist operation time and
    /// successor identity atomically, then reuse both on retries. Ending the previous SERVICE
    /// does not shorten the expiration of its existing call-credit record.</remarks>
    public sealed class LegacyBilledRenewal
    {
        public Guid PreviousServiceId { get; private set; }
        public Guid ContextId { get; private set; }
        public DateTime PreviousServiceEndUtc { get; private set; }
        public DateTime StartUtc { get; private set; }
        public DateTime ExpirationUtc { get; private set; }
        public decimal Value { get; private set; }
        public bool HasCallCredit => Value > 0;

        /// <summary>Operation time must be the persisted UTC whole-second delivery timestamp.</summary>
        public static LegacyBilledRenewal Calculate(LegacyRenewalSnapshot source,
            TimeZoneInfo sourceTimeZone, DateTime operationUtc)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (sourceTimeZone == null) throw new ArgumentNullException(nameof(sourceTimeZone));
            if (operationUtc.Kind != DateTimeKind.Utc || operationUtc.Year < 1000
                || operationUtc > DateTime.MaxValue.AddMonths(-6)
                || operationUtc.Ticks % TimeSpan.TicksPerSecond != 0)
                throw new ArgumentException("Persisted UTC whole-second operation time is required.", nameof(operationUtc));
            if (source.ServiceId == Guid.Empty || source.ContextId == Guid.Empty || source.Renewed)
                throw new InvalidOperationException("An identified unrenewed predecessor is required.");
            var start = LegacyMonthlyRenewal.Utc(source.Start, sourceTimeZone);
            var previousEnd = operationUtc.AddSeconds(-1);
            if (start >= previousEnd)
                throw new InvalidOperationException("The predecessor must start before the renewal boundary.");
            var value = source.Value.GetValueOrDefault();
            if (value < 0 || value > 999999.9999m || decimal.Round(value, 4) != value)
                throw new InvalidOperationException("Value cannot be represented by the call-credit destination.");
            return new LegacyBilledRenewal { PreviousServiceId = source.ServiceId, ContextId = source.ContextId,
                PreviousServiceEndUtc = previousEnd, StartUtc = operationUtc,
                ExpirationUtc = operationUtc.AddMonths(6), Value = value };
        }
    }
}
