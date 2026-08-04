using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Defines the provider-specific, read-only diagnostics boundary.
    /// </summary>
    public interface IBankSlipProviderDiagnosticsGateway
    {
        string ProviderCode { get; }

        Task<BankSlipProviderDiagnosticGatewayResult?> ExecuteDiagnosticAsync(
            BankSlipProviderDiagnosticParameters parameters,
            BankSlipGatewayContext context,
            CancellationToken cancellationToken);
    }
}
