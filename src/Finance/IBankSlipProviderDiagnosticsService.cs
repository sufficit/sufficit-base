using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Defines the tenant-aware administrative diagnostics application boundary.
    /// </summary>
    public interface IBankSlipProviderDiagnosticsService
    {
        Task<BankSlipProviderDiagnosticResult?> ExecuteAsync(
            Guid tenantId,
            Guid requestedBy,
            BankSlipProviderDiagnosticParameters parameters,
            CancellationToken cancellationToken);
    }
}
