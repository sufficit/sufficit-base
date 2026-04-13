using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.InterConnection
{
    /// <summary>
    ///     Canonical credential row attached to one interconnection.
    ///     The runtime projects this neutral model to engine-specific auth objects.
    ///     The collection stays 1:N on purpose even if many tenants use only one
    ///     credential today: inbound and outbound legs may legitimately require
    ///     different usernames/secrets for the same interconnection. Keep the
    ///     stable credential id even if the current UI shows credentials as a
    ///     flat list: the parent interconnection selects which credential is
    ///     used for inbound and outbound legs through explicit references.
    /// </summary>
    public class InterconnectionCredential : ITimestamp
    {
        /// <summary>
        ///     Stable identity kept to match the aggregate pattern used across the
        ///     telephony catalog. A composed key based only on parent/position would
        ///     be cheaper, but this id survives reorder/import/sync flows without
        ///     coupling identity to a mutable slot or username.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Parent ownership. One interconnection may own more than one
        ///     credential row when ingress and egress auth differ.
        /// </summary>
        public Guid InterconnectionId { get; set; }

        public string? ExternalKey { get; set; }

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
