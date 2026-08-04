using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Resolves a provider callback token into its immutable event history.
    /// </summary>
    public interface IBankSlipProviderNotificationGateway
    {
        string ProviderCode { get; }

        Task<BankSlipProviderNotificationBatch> GetNotificationAsync(
            string notificationToken,
            BankSlipGatewayContext context,
            CancellationToken cancellationToken);
    }
}
