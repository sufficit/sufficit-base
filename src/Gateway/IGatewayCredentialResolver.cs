using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Gateway
{
    /// <summary>
    /// Resolves tenant-scoped credentials for any capability exposed by a
    /// provider gateway.
    /// </summary>
    public interface IGatewayCredentialResolver
    {
        Task<GatewayCredential> GetRequiredAsync(
            string providerCode,
            GatewayCallContext context,
            CancellationToken cancellationToken);
    }
}
