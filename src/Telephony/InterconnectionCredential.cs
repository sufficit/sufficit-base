using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Canonical credential row attached to one interconnection.
    ///     The runtime projects this neutral model to engine-specific auth objects.
    /// </summary>
    public class InterconnectionCredential : ITimestamp
    {
        public Guid Id { get; set; }

        public Guid InterconnectionId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? ExternalKey { get; set; }

        public string? SourceTable { get; set; }

        public string AuthType { get; set; } = "userpass";

        public string? Username { get; set; }

        public string? Secret { get; set; }

        public string? Realm { get; set; }

        public bool Enabled { get; set; } = true;

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }

        public DateTime? DeletedAtUtc { get; set; }

        /// <summary>
        ///     Reverse navigation used by EF only.
        ///     The API returns the interconnection aggregate from the root and
        ///     must avoid serializing this property to prevent object cycles.
        /// </summary>
        [JsonIgnore]
        public Interconnection? Interconnection { get; set; }
    }
}
