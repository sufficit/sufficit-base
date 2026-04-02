using System;
using System.Collections.Generic;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Canonical telephony interconnection owned by one customer context.
    /// </summary>
    public class Interconnection
    {
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Technology { get; set; } = "PJSIP";

        public InterconnectionDirection Direction { get; set; } = InterconnectionDirection.Both;

        public InterconnectionAuthMode AuthMode { get; set; } = InterconnectionAuthMode.IP;

        public InterconnectionCliMode CliMode { get; set; } = InterconnectionCliMode.Identified;

        public int ChannelLimit { get; set; } = 1;

        public string InboundProfile { get; set; } = "customer-default";

        public string OutboundProfile { get; set; } = "customer-default";

        public string? Username { get; set; }

        public string? Secret { get; set; }

        public string? FromUser { get; set; }

        public string? FromDomain { get; set; }

        public bool Enabled { get; set; } = true;

        public string ProvisioningStatus { get; set; } = "draft";

        public string? Comments { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }

        public ICollection<InterconnectionHost> Hosts { get; set; } = new HashSet<InterconnectionHost>();
    }
}
