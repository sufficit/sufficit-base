using System;
using System.Collections.Generic;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Experimental catalog entry for a customer-managed outbound trunk.
    /// </summary>
    /// <remarks>
    ///     TODO: connect provisioning status with the real PJSIP/realtime synchronization workflow.
    /// </remarks>
    public class OutboundCustomerTrunk
    {
        /// <summary>
        ///     Unique identifier of the trunk catalog entry.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Customer context that owns the trunk.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Human-readable title for managers and support teams.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        ///     Signaling technology used by the trunk.
        /// </summary>
        public string Technology { get; set; } = "PJSIP";

        /// <summary>
        ///     Transport metadata expected by the customer catalog.
        /// </summary>
        public string Transport { get; set; } = "udp";

        /// <summary>
        ///     Optional authentication username.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        ///     Optional authentication secret.
        /// </summary>
        public string? Secret { get; set; }

        /// <summary>
        ///     Optional From user to present towards the carrier.
        /// </summary>
        public string? FromUser { get; set; }

        /// <summary>
        ///     Optional From domain to present towards the carrier.
        /// </summary>
        public string? FromDomain { get; set; }

        /// <summary>
        ///     Operator-defined maximum simultaneous outbound channels.
        /// </summary>
        public int MaxChannels { get; set; } = 1;

        /// <summary>
        ///     Whether anonymous CLI is allowed for this trunk.
        /// </summary>
        public bool AllowOpenCli { get; set; }

        /// <summary>
        ///     Whether identified CLI is allowed for this trunk.
        /// </summary>
        public bool AllowIdentifiedCli { get; set; } = true;

        /// <summary>
        ///     Indicates whether the trunk can participate in route previews.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        ///     Current provisioning status tracked by the experimental workflow.
        /// </summary>
        public string ProvisioningStatus { get; set; } = "draft";

        /// <summary>
        ///     Free-form operator notes.
        /// </summary>
        public string? Comments { get; set; }

        /// <summary>
        ///     Creation timestamp in UTC.
        /// </summary>
        public DateTime CreatedAtUtc { get; set; }

        /// <summary>
        ///     Last update timestamp in UTC.
        /// </summary>
        public DateTime? UpdatedAtUtc { get; set; }

        /// <summary>
        ///     Candidate hosts/endpoints available for this trunk.
        /// </summary>
        public ICollection<OutboundCustomerTrunkHost> Hosts { get; set; } = new HashSet<OutboundCustomerTrunkHost>();
    }
}
