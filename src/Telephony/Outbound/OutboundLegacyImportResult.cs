using System;
using System.Collections.Generic;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Result of importing legacy outbound trunk availability into the experimental outbound assignment catalog.
    /// </summary>
    public class OutboundLegacyImportResult
    {
        public Guid ContextId { get; set; }

        public DateTime ImportedAtUtc { get; set; }

        public int CreatedCount { get; set; }

        public int UpdatedCount { get; set; }

        public int CreatedRouteRuleCount { get; set; }

        public int UpdatedRouteRuleCount { get; set; }

        public int SkippedCount { get; set; }

        public List<OutboundLegacyImportedAssignment> Items { get; set; } = new List<OutboundLegacyImportedAssignment>();

        public List<string> Notes { get; set; } = new List<string>();
    }

    /// <summary>
    ///     One assignment snapshot generated from a legacy outbound trunk title.
    /// </summary>
    public class OutboundLegacyImportedAssignment
    {
        public string LegacyTrunkTitle { get; set; } = string.Empty;

        public Guid AssignmentId { get; set; }

        public OutboundServiceType ServiceType { get; set; } = OutboundServiceType.UNKNOWN;

        public int? ChannelLimit { get; set; }

        public int Priority { get; set; }

        public string? RouteProfile { get; set; }

        public int RouteRuleCount { get; set; }

        public bool Created { get; set; }
    }
}
