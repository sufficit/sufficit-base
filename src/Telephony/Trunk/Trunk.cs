using System;
using System.Collections.Generic;

namespace Sufficit.Telephony.Trunk
{
    /// <summary>
    ///     Experimental catalog entry for a telephony trunk.
    /// </summary>
    /// <remarks>
    ///     TODO: connect provisioning status with the real PJSIP/realtime synchronization workflow for inbound and outbound directions.
    /// </remarks>
    public class Trunk
    {
        /// <summary>
        ///     Unique identifier of the trunk catalog entry.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Optional customer context that scopes the trunk.
        ///     When empty, the trunk is shared/global.
        /// </summary>
        public Guid? ContextId { get; set; }

        /// <summary>
        ///     Human-readable title for managers and support teams.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        ///     Signaling technology used by the trunk.
        /// </summary>
        public string Technology { get; set; } = "PJSIP";

        /// <summary>
        ///     Transport metadata expected by the trunk catalog.
        /// </summary>
        public string Transport { get; set; } = "udp";

        /// <summary>
        ///     Unique prefix used to namespace generated Asterisk objects and avoid conflicts with existing realtime entries.
        /// </summary>
        public string AsteriskPrefix { get; set; } = string.Empty;

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
        ///     Whether the trunk may be provisioned for inbound traffic.
        /// </summary>
        public bool AllowInbound { get; set; }

        /// <summary>
        ///     Whether the trunk may be used by outbound services.
        /// </summary>
        public bool AllowOutbound { get; set; } = true;

        /// <summary>
        ///     Asterisk dialplan context expected for inbound matching when the trunk is provisioned for receiving traffic.
        /// </summary>
        public string InboundContext { get; set; } = "from-trunks";

        /// <summary>
        ///     Whether anonymous CLI is allowed for this trunk.
        /// </summary>
        public bool AllowOpenCli { get; set; }

        /// <summary>
        ///     Whether identified CLI is allowed for this trunk.
        /// </summary>
        public bool AllowIdentifiedCli { get; set; } = true;

        /// <summary>
        ///     Indicates whether the trunk can participate in previews and provisioning workflows.
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
        public ICollection<TrunkHost> Hosts { get; set; } = new HashSet<TrunkHost>();
    }
}


