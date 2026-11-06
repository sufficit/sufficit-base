using System;

namespace Sufficit.Sales
{
    /// <summary>Customer + catalog service coverage policy, independent of price and recurrence.</summary>
    public enum ServiceOverlapPolicy : byte
    {
        Allow = 0,
        Reject = 1,
        ReplacePrevious = 2
    }

    public static class ServiceActivationPolicy
    {
        public static bool Overlaps(DateTime? start, DateTime? end, DateTime? otherStart, DateTime? otherEnd)
            => (!end.HasValue || !otherStart.HasValue || end.Value >= otherStart.Value)
                && (!otherEnd.HasValue || !start.HasValue || otherEnd.Value >= start.Value);

        /// <summary>Stored service dates are inclusive at second precision. Never extend expired coverage.</summary>
        public static DateTime ReplacementEnd(DateTime previousStart, DateTime? previousEnd, DateTime nextStart)
        {
            if (nextStart <= previousStart || nextStart - previousStart < TimeSpan.FromSeconds(1))
                throw new InvalidOperationException("A nova ativação deve ser posterior, respeitando a precisão de segundos.");
            var end = nextStart.AddSeconds(-1);
            return previousEnd.HasValue && previousEnd.Value < end ? previousEnd.Value : end;
        }
    }
}
