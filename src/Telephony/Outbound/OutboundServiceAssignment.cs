using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Sufficit.Telephony;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Experimental outbound routing assignment for a specific customer context and service type.
    /// </summary>
    /// <remarks>
    ///     TODO: replace manual assignment maintenance with telephony-side projections fed by recurring service events.
    /// </remarks>
    public class OutboundServiceAssignment
    {
        /// <summary>
        ///     Unique identifier of the assignment row.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Customer context that owns the outbound rule.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Outbound product family resolved by this assignment.
        /// </summary>
        public OutboundServiceType ServiceType { get; set; } = OutboundServiceType.UNKNOWN;

        /// <summary>
        ///     Indicates whether the assignment may be considered during route preview.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        ///     Lower values win when multiple assignments exist for the same service type.
        /// </summary>
        public int Priority { get; set; } = 100;

        /// <summary>
        ///     Optional per-assignment channel cap.
        /// </summary>
        public int? ChannelLimit { get; set; }

        /// <summary>
        ///     Named realtime route profile used by non-BYOC routes.
        /// </summary>
        public string? RouteProfile { get; set; }

        /// <summary>
        ///     Calling identity policy requested by this assignment.
        /// </summary>
        public OutboundIdentityPolicy IdentityPolicy { get; set; } = OutboundIdentityPolicy.DEFAULT;

        /// <summary>
        ///     Optional default DID to expose when the policy needs a fixed identity.
        /// </summary>
        public Guid? DefaultDidId { get; set; }

        /// <summary>
        ///     Optional customer-managed trunk for BYOC routing.
        /// </summary>
        public Guid? CustomerTrunkId { get; set; }

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
        ///     Optional non-persisted navigation payload used by previews and API responses.
        /// </summary>
        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomerTrunk? CustomerTrunk { get; set; }
    }
}
