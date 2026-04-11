using System;
using System.Collections.Generic;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Result of importing legacy suff_dialout_trunks rows into the telephony-owned customer-service projection table.
    /// </summary>
    public class OutboundCustomerServiceLegacyImportResult
    {
        public DateTime ImportedAtUtc { get; set; }

        public int ContextCount { get; set; }

        public int CreatedCount { get; set; }

        public int UpdatedCount { get; set; }

        public int SkippedCount { get; set; }

        public List<OutboundCustomerServiceLegacyImportedItem> Items { get; set; } = new List<OutboundCustomerServiceLegacyImportedItem>();

        public List<string> Notes { get; set; } = new List<string>();
    }

    /// <summary>
    ///     One telephony customer-service projection generated from a legacy outbound trunk row.
    /// </summary>
    public class OutboundCustomerServiceLegacyImportedItem
    {
        public Guid ContextId { get; set; }

        public string LegacyTrunkTitle { get; set; } = string.Empty;

        public Guid CustomerServiceId { get; set; }

        public Guid ServiceId { get; set; }

        public string ServiceTitle { get; set; } = string.Empty;

        public int Channels { get; set; }

        public int Quantity { get; set; }

        public DateTime? ExpirationUtc { get; set; }

        public bool Created { get; set; }
    }
}
