using System;
using System.Collections.Generic;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    /// Moves one source to a zero-based position and assigns unambiguous priorities.
    /// The input must already be sorted by priority, kind and identifier.
    /// </summary>
    public static class OutboundRouteSourceOrder
    {
        public static bool TryMove(IList<OutboundRouteSource> sources, Guid routeSourceId, int targetIndex)
        {
            if (targetIndex < 0 || targetIndex >= sources.Count)
                return false;

            var sourceIndex = -1;
            for (var index = 0; index < sources.Count; index++)
            {
                if (sources[index].Id == routeSourceId)
                {
                    sourceIndex = index;
                    break;
                }
            }

            if (sourceIndex < 0 || sourceIndex == targetIndex)
                return false;

            var source = sources[sourceIndex];
            sources.RemoveAt(sourceIndex);
            sources.Insert(targetIndex, source);
            for (var index = 0; index < sources.Count; index++)
                sources[index].Priority = checked((index + 1) * 10);

            return true;
        }
    }
}
