using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Canonical telephony-owned outbound service catalog entry.
    /// </summary>
    public class OutboundCatalogService
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public OutboundServiceType ServiceType { get; set; } = OutboundServiceType.UNKNOWN;

        public OutboundIdentityPolicy IdentityPolicy { get; set; } = OutboundIdentityPolicy.DEFAULT;

        public int? DefaultChannelLimit { get; set; }

        public int? DefaultRequestLimit { get; set; }

        public int? DefaultRequestWindowHours { get; set; }

        public bool DefaultFailOpenOnBillingError { get; set; } = true;

        public bool AllowSufficitInterconnections { get; set; } = true;

        public bool AllowCustomerInterconnections { get; set; }

        public bool Enabled { get; set; } = true;

        public string? Comments { get; set; }

        public DateTime UpdatedAtUtc { get; set; }
    }
}
