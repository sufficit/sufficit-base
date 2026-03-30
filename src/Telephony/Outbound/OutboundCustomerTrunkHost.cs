using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Reachable host belonging to an experimental customer-managed outbound trunk.
    /// </summary>
    public class OutboundCustomerTrunkHost
    {
        /// <summary>
        ///     Unique identifier of the host row.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Parent customer trunk identifier.
        /// </summary>
        public Guid CustomerTrunkId { get; set; }

        /// <summary>
        ///     Human-readable title for the host target.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        ///     DNS name or IP address used for signaling.
        /// </summary>
        public string Host { get; set; } = string.Empty;

        /// <summary>
        ///     Signaling port.
        /// </summary>
        public int Port { get; set; } = 5060;

        /// <summary>
        ///     Lower values win during host selection.
        /// </summary>
        public int Priority { get; set; } = 1;

        /// <summary>
        ///     Higher values win when priorities tie.
        /// </summary>
        public int Weight { get; set; } = 1;

        /// <summary>
        ///     Whether qualify should be enabled for the generated preview.
        /// </summary>
        public bool Qualify { get; set; } = true;

        /// <summary>
        ///     Indicates whether the host can be selected.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        ///     Optional explicit Asterisk endpoint name.
        /// </summary>
        public string? AsteriskEndpoint { get; set; }

        /// <summary>
        ///     Creation timestamp in UTC.
        /// </summary>
        public DateTime CreatedAtUtc { get; set; }

        /// <summary>
        ///     Last update timestamp in UTC.
        /// </summary>
        public DateTime? UpdatedAtUtc { get; set; }
    }
}
