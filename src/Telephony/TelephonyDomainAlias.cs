using System;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Canonical local SIP domain accepted by the telephony platform.
    /// </summary>
    public class TelephonyDomainAlias : ITimestamp
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? ExternalKey { get; set; }

        public string Domain { get; set; } = string.Empty;

        public bool Enabled { get; set; } = true;

        public string? Comments { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }

        public DateTime? DeletedAtUtc { get; set; }
    }
}
