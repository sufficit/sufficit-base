using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Identifies the tenant-specific provider configuration used by a gateway call.
    /// </summary>
    public class BankSlipGatewayContext
    {
        public Guid TenantId { get; set; }
        public BankSlipProviderEnvironment Environment { get; set; } = BankSlipProviderEnvironment.Sandbox;
        public string CredentialReference { get; set; } = string.Empty;
    }
}
