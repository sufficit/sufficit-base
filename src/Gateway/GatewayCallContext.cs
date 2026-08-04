using System;

namespace Sufficit.Gateway
{
    /// <summary>
    /// Carries tenant-scoped provider configuration without coupling it to a
    /// specific gateway capability such as bank slips or invoices.
    /// </summary>
    public class GatewayCallContext
    {
        public Guid TenantId { get; set; }
        public GatewayEnvironment Environment { get; set; } = GatewayEnvironment.Sandbox;
        public string CredentialReference { get; set; } = string.Empty;
    }
}
