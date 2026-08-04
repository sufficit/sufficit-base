using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Resolves provider credentials without persisting secrets in finance records.
    /// </summary>
    public interface IBankSlipCredentialResolver
    {
        Task<BankSlipProviderCredential> GetRequiredAsync(
            string providerCode,
            BankSlipGatewayContext context,
            CancellationToken cancellationToken);
    }
}
