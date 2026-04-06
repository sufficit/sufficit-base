using System;
using System.Collections.Generic;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Operational runtime status for one customer trunk host projected into Asterisk realtime.
    /// </summary>
    public class CustomerTrunkHostOperationalStatus
    {
        public Guid HostId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Host { get; set; } = string.Empty;

        public int Port { get; set; }

        public string EndpointId { get; set; } = string.Empty;

        public string AorId { get; set; } = string.Empty;

        public string? AuthId { get; set; }

        public bool QualifyEnabled { get; set; }

        public bool EndpointProvisioned { get; set; }

        public bool AorProvisioned { get; set; }

        public bool AuthProvisioned { get; set; }

        public bool IdentifyProvisioned { get; set; }

        public bool ContactObserved { get; set; }

        public string RegistrationStatus { get; set; } = "not-configured";

        public bool RegistrationConfigured { get; set; }

        public string? ContactStatus { get; set; }

        public bool? Reachable { get; set; }

        public double? LatencyMs { get; set; }

        public string? ContactUri { get; set; }

        public string? UserAgent { get; set; }

        public string? ViaAddress { get; set; }

        public int? ViaPort { get; set; }

        public DateTime? ContactExpiresAtUtc { get; set; }

        public ICollection<string> Notes { get; set; } = new List<string>();
    }
}
