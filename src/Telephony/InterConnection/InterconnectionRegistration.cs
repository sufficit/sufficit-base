using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.InterConnection
{
    /// <summary>
    ///     Canonical registration row attached to one interconnection.
    /// </summary>
    public class InterconnectionRegistration : ITimestamp
    {
        public Guid Id { get; set; }

        public Guid InterconnectionId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? ExternalKey { get; set; }

        /// <summary>
        ///     Canonical Asterisk <c>systemname</c> that owns this registration,
        ///     e.g. <c>apoint</c>, <c>eveo</c> or <c>freepbx</c>.
        ///     The admin UI may accept short aliases for convenience, but the
        ///     persisted value should always be normalized to the actual
        ///     <c>systemname</c> declared in each server's <c>asterisk.conf</c>.
        /// </summary>
        public string? Node { get; set; }

        public string? Transport { get; set; }

        public string? OutboundAuthRef { get; set; }

        public string? ServerUri { get; set; }

        public string? ClientUri { get; set; }

        public string? ContactUser { get; set; }

        public int? Expiration { get; set; }

        public int? RetryInterval { get; set; }

        public int? ForbiddenRetryInterval { get; set; }

        public int? FatalRetryInterval { get; set; }

        public int? MaxRetries { get; set; }

        public string? AuthRejectionPermanent { get; set; }

        public string? Line { get; set; }

        public string? EndpointRef { get; set; }

        public string? OutboundProxy { get; set; }

        public string? SupportPath { get; set; }

        public bool Enabled { get; set; } = true;

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }

        public DateTime? DeletedAtUtc { get; set; }

        /// <summary>
        ///     Reverse navigation used only while materializing the aggregate.
        ///     Serializing it would re-enter the root interconnection and create
        ///     an infinite graph for the API payload.
        /// </summary>
        [JsonIgnore]
        public Interconnection? Interconnection { get; set; }
    }
}
