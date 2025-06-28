using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace Sufficit.Identity
{
    /// <summary>
    /// Represents a persisted grant, which is used to store authorization data for a client and subject.
    /// </summary>
    /// <remarks>Persisted grants are typically used in scenarios such as authorization codes, refresh tokens,
    /// or other long-lived tokens that need to be stored securely. Each grant is associated with a client, and
    /// optionally a subject (user) and session. The grant data is stored in a serialized format.</remarks>
    public class PersistedGrant
    {
        public string Key { get; set; } = default!;

        public string Type { get; set; } = default!;

        public Guid? SubjectId { get; set; }

        public string ClientId { get; set; } = default!;

        public DateTimeOffset Creation { get; set; }

        public DateTimeOffset? Expiration { get; set; }

        public DateTimeOffset? Consumed { get; set; }

        public JsonNode Data { get; set; } = default!;

        public string? Description { get; set; }

        public Guid? SessionId { get; set; }
    }
}
