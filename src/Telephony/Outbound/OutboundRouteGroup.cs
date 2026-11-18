using System;

namespace Sufficit.Telephony.Outbound
{
    public enum OutboundRouteDistribution
    {
        Sequential,
        Smart,
        Distributed,
    }

    /// <summary>Ordered members of a route. Each member retains its own authorization and identifier.</summary>
    public sealed class OutboundRouteGroup
    {
        public string Title { get; set; } = string.Empty;

        public OutboundRouteDistribution Distribution { get; set; }

        /// <summary>Route source IDs in attempt order, including the source that owns the group.</summary>
        public Guid[] SourceIds { get; set; } = Array.Empty<Guid>();
    }

    /// <summary>Versioned group and the editable source rows saved with it.</summary>
    public sealed class OutboundRouteGroupUpdate
    {
        public OutboundRouteSource Route { get; set; } = new OutboundRouteSource();

        public OutboundRouteSource[] Members { get; set; } = Array.Empty<OutboundRouteSource>();
    }
}
