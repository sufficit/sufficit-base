using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Sales
{
    /// <summary>Read-only monthly renewal proposal. This is not a service or a credit identity.</summary>
    public sealed class LegacyMonthlyRenewal
    {
        public Guid SourceServiceId { get; private set; }
        public Guid ContextId { get; private set; }
        public DateTime StartUtc { get; private set; }
        public DateTime EndUtc { get; private set; }
        public DateTime BillingUtc { get; private set; }
        /// <summary>Preserves an explicitly absent legacy billing date on coordinated commands.</summary>
        public DateTime? BillingUtcOrNull { get; private set; }
        public decimal Value { get; private set; }
        public Guid? CommissionedId { get; private set; }
        public decimal Commission { get; private set; }
        public bool CollisionAdjusted { get; private set; }

        /// <summary>Mirrors generic legacy monthly dates; excludes billed/top-up renewal.</summary>
        /// <remarks>Unspecified dates require the declared source timezone, never the executing
        /// machine timezone. Shared-trunk coverage must include all relevant source intervals
        /// from the same customer, read in the same consistency boundary as the source service.
        /// This calculation creates no GUID, ledger entry, sale, route or automatic authorization.</remarks>
        public static LegacyMonthlyRenewal Calculate(LegacyRenewalSnapshot source, TimeZoneInfo sourceTimeZone,
            bool sharedTrunk, IEnumerable<LegacyRenewalSnapshot>? sharedCoverage = null)
            => Calculate(source, sourceTimeZone, sharedTrunk, sharedCoverage, false);

        public static LegacyMonthlyRenewal Calculate(LegacyRenewalSnapshot source, TimeZoneInfo sourceTimeZone,
            bool sharedTrunk, IEnumerable<LegacyRenewalSnapshot>? sharedCoverage, bool preserveMissingBilling)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (sourceTimeZone == null) throw new ArgumentNullException(nameof(sourceTimeZone));
            if (source.ServiceId == Guid.Empty || source.ContextId == Guid.Empty || source.Renewed
                || (!preserveMissingBilling && !source.Billing.HasValue))
                throw new InvalidOperationException("Complete unrenewed source evidence is required.");
            var start = Utc(source.Start, sourceTimeZone);
            var end = Utc(source.End, sourceTimeZone);
            if (end < start) throw new InvalidOperationException("Source interval is inverted.");
            var nextEnd = source.End.AddMonths(1);
            // Legacy preserves month-end based on the original source calendar, before UTC conversion.
            var monthEnd = source.End.Day == DateTime.DaysInMonth(source.End.Year, source.End.Month);
            var extraDays = monthEnd
                ? DateTime.DaysInMonth(nextEnd.Year, nextEnd.Month) - nextEnd.Day : 0;
            var result = new LegacyMonthlyRenewal
            {
                SourceServiceId = source.ServiceId, ContextId = source.ContextId,
                StartUtc = start.AddMonths(1), EndUtc = monthEnd
                    ? Utc(nextEnd, sourceTimeZone).AddDays(extraDays) : end.AddMonths(1),
                BillingUtc = source.Billing.HasValue ? Utc(source.Billing.Value, sourceTimeZone).AddMonths(1) : default,
                BillingUtcOrNull = source.Billing.HasValue ? Utc(source.Billing.Value, sourceTimeZone).AddMonths(1) : (DateTime?)null,
                Value = source.Value.GetValueOrDefault(),
                CommissionedId = source.CommissionedId, Commission = source.Commission.GetValueOrDefault()
            };
            if (sharedTrunk)
            {
                if (sharedCoverage == null) throw new InvalidOperationException("Shared trunk coverage is required.");
                var coverage = sharedCoverage.ToArray();
                if (coverage.Any(x => x.ContextId != source.ContextId))
                    throw new InvalidOperationException("Coverage belongs to another customer.");
                var duration = result.EndUtc - result.StartUtc;
                if (duration >= TimeSpan.FromDays(28) && duration <= TimeSpan.FromDays(32)
                    && coverage.Any(x => result.StartUtc >= Utc(x.Start, sourceTimeZone)
                        && result.StartUtc <= Utc(x.End, sourceTimeZone)))
                {
                    result.StartUtc = end.AddDays(1);
                    result.CollisionAdjusted = true;
                }
            }
            if (result.EndUtc < result.StartUtc) throw new InvalidOperationException("Renewal interval is inverted.");
            return result;
        }

        public static bool Collides(DateTime startUtc, IEnumerable<LegacyRenewalSnapshot> coverage, TimeZoneInfo zone)
        {
            if (startUtc.Kind != DateTimeKind.Utc) throw new ArgumentException("UTC start required.", nameof(startUtc));
            return coverage.Any(x => startUtc >= Utc(x.Start, zone) && startUtc <= Utc(x.End, zone));
        }

        internal static DateTime Utc(DateTime date, TimeZoneInfo sourceTimeZone)
        {
            if (date.Kind == DateTimeKind.Utc) return date;
            if (date.Kind == DateTimeKind.Local)
                throw new InvalidOperationException("Local machine dates are not portable renewal evidence.");
            if (sourceTimeZone.IsInvalidTime(date) || sourceTimeZone.IsAmbiguousTime(date))
                throw new InvalidOperationException("Source timezone requires an explicit timestamp offset.");
            return TimeZoneInfo.ConvertTimeToUtc(date, sourceTimeZone);
        }
    }
}
