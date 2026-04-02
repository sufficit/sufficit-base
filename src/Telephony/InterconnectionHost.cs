using System;

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

        public string Host { get; set; } = string.Empty;

        public int Port { get; set; } = 5060;

        public string Transport { get; set; } = "udp";

        public int Priority { get; set; } = 1;

        public int Weight { get; set; } = 1;

        public bool Qualify { get; set; } = true;

        public bool Enabled { get; set; } = true;

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }
    }
}
