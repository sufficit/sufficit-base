using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Reachable host target attached to one customer interconnection.
    /// </summary>
    public class InterconnectionHost
    {
        public Guid Id { get; set; }

        public Guid InterconnectionId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? ExternalKey { get; set; }

        public string? SourceTable { get; set; }

        public string Host { get; set; } = string.Empty;

        public int Port { get; set; } = 5060;

        public string Transport { get; set; } = "udp";

        public int Priority { get; set; } = 1;

        public int Weight { get; set; } = 1;

        public bool Qualify { get; set; } = true;

        public bool Enabled { get; set; } = true;

        /// <summary>
        ///     Canonical contact URI used when the engine requires a static address-of-record contact.
        /// </summary>
        public string? ContactUri { get; set; }

        public int? MaxContacts { get; set; }

        public int? QualifyFrequency { get; set; }

        public string? OutboundProxy { get; set; }

        public string? SupportPath { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }

        /// <summary>
        ///     Reverse navigation kept only for EF/runtime graph management.
        ///     The canonical API serializes the aggregate from the root and must
        ///     not emit this back-reference, otherwise JSON cycles are created.
        /// </summary>
        [JsonIgnore]
        public Interconnection? Interconnection { get; set; }
    }
}
