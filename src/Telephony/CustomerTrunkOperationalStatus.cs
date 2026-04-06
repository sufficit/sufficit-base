using System;
using System.Collections.Generic;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Operational runtime status for one customer-managed trunk.
    /// </summary>
    public class CustomerTrunkOperationalStatus
    {
        public Guid TrunkId { get; set; }

        public Guid ContextId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Technology { get; set; } = string.Empty;

        public string AsteriskPrefix { get; set; } = string.Empty;

        public string ProvisioningStatus { get; set; } = string.Empty;

        public bool Provisioned { get; set; }

        public bool MonitoringAvailable { get; set; }

        public bool RegistrationConfigured { get; set; }

        public string RegistrationStatus { get; set; } = "not-configured";

        public bool? Reachable { get; set; }

        public int ProvisionedEndPointCount { get; set; }

        public int ProvisionedAorCount { get; set; }

        public int ProvisionedAuthCount { get; set; }

        public int ProvisionedIdentifyCount { get; set; }

        public int ObservedContactCount { get; set; }

        public int ReachableHostCount { get; set; }

        public int UnreachableHostCount { get; set; }

        public int UnknownHostCount { get; set; }

        public ICollection<CustomerTrunkHostOperationalStatus> Hosts { get; set; } = new List<CustomerTrunkHostOperationalStatus>();

        public ICollection<string> Notes { get; set; } = new List<string>();
    }
}
