using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Defines provider-independent bank slip operations.
    /// </summary>
    public interface IBankSlipGateway
    {
        string ProviderCode { get; }

        Task<ProviderBankSlipResult> CreateAsync(
            BankSlipGatewayIssueRequest request,
            BankSlipGatewayContext context,
            CancellationToken cancellationToken);

        Task<ProviderBankSlipResult?> GetAsync(
            string providerChargeId,
            BankSlipGatewayContext context,
            CancellationToken cancellationToken);

        Task<ProviderBankSlipCancellationResult> CancelAsync(
            string providerChargeId,
            BankSlipGatewayContext context,
            CancellationToken cancellationToken);
    }
}
