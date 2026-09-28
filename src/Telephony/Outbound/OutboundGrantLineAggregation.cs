using System;
using System.Collections.Generic;

namespace Sufficit.Telephony.Outbound
{
    public sealed class OutboundGrantLineAggregate
    {
        public int Channels { get; set; }
        public DateTime? NextExpirationUtc { get; set; }
        public string Reason { get; set; } = string.Empty;
        public List<Guid> ActiveLineIds { get; } = new List<Guid>();
    }

    /// <summary>Pure evaluation of one product's overlapping commercial lines.</summary>
    public static class OutboundGrantLineAggregation
    {
        public static OutboundGrantLineAggregate Evaluate(
            Guid contextId, Guid serviceId, OutboundGrantAggregationPolicy policy,
            IEnumerable<OutboundCommercialGrantLine> lines, DateTime utcNow)
        {
            if (utcNow.Kind != DateTimeKind.Utc)
                throw new ArgumentException("UTC clock required", nameof(utcNow));
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));

            var result = new OutboundGrantLineAggregate { Reason = "NoActiveLine" };
            var max = 0;
            foreach (var line in lines)
            {
                if (line.ContextId != contextId || line.ServiceId != serviceId || !line.IsEligibleAt(utcNow))
                    continue;

                result.ActiveLineIds.Add(line.Id);
                if (!result.NextExpirationUtc.HasValue || line.ExpirationUtc < result.NextExpirationUtc.Value)
                    result.NextExpirationUtc = line.ExpirationUtc;
                max = Math.Max(max, line.Channels);
                if (policy == OutboundGrantAggregationPolicy.SumChannels)
                    result.Channels = checked(result.Channels + line.Channels);
            }

            if (result.ActiveLineIds.Count == 0)
                return result;
            if (policy == OutboundGrantAggregationPolicy.RejectOverlap && result.ActiveLineIds.Count > 1)
            {
                result.Channels = 0;
                result.Reason = "OverlappingLinesRequirePolicy";
                return result;
            }
            if (policy == OutboundGrantAggregationPolicy.MaxChannels
                || policy == OutboundGrantAggregationPolicy.RejectOverlap)
                result.Channels = max;
            if (policy != OutboundGrantAggregationPolicy.RejectOverlap
                && policy != OutboundGrantAggregationPolicy.SumChannels
                && policy != OutboundGrantAggregationPolicy.MaxChannels)
            {
                result.Channels = 0;
                result.Reason = "UnknownAggregationPolicy";
                return result;
            }
            result.Reason = "Active";
            return result;
        }
    }
}
