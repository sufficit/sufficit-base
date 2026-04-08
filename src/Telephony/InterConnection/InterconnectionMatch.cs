using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.InterConnection
{
    /// <summary>
    ///     Canonical inbound matching rule attached to one interconnection.
    /// </summary>
    public class InterconnectionMatch : ITimestamp
    {
        public Guid Id { get; set; }

        public Guid InterconnectionId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? ExternalKey { get; set; }

        public string? MatchValue { get; set; }

        public string? MatchHeader { get; set; }

        public string? SrvLookups { get; set; }

        public bool Enabled { get; set; } = true;

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }

        public DateTime? DeletedAtUtc { get; set; }

        /// <summary>
        ///     Reverse navigation used internally by EF.
        ///     It is ignored in JSON so the canonical aggregate stays acyclic.
        /// </summary>
        [JsonIgnore]
        public Interconnection? Interconnection { get; set; }
    }
}
