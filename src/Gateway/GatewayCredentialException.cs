using System;

namespace Sufficit.Gateway
{
    /// <summary>
    /// Indicates that a protected credential could not be resolved for a
    /// provider call.
    /// </summary>
    public sealed class GatewayCredentialException : Exception
    {
        public GatewayCredentialException(string providerCode)
            : base($"Credentials for gateway provider '{providerCode}' are unavailable.")
        {
            ProviderCode = providerCode;
        }

        public string ProviderCode { get; }
    }
}
