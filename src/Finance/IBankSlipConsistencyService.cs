using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Integration boundary used by the scheduler. Implementations reconcile
    /// durable facts without exposing either module's runtime to the other.
    /// </summary>
    public interface IBankSlipConsistencyService
    {
        Task<BankSlipConsistencyResult> ReconcileAsync(
            BankSlipConsistencyRequest request,
            CancellationToken cancellationToken);

        /// <summary>
        /// Compares the provider inventory with the canonical local ledger for
        /// one tenant without changing either side.
        /// </summary>
        Task<BankSlipReconciliationReport> CompareAsync(
            Guid tenantId,
            BankSlipReconciliationRequest request,
            CancellationToken cancellationToken);

        /// <summary>
        /// Requeries selected provider charges and reapplies their authoritative
        /// state through the canonical aggregate/outbox pipeline.
        /// </summary>
        Task<BankSlipReconciliationReprocessReport> ReprocessAsync(
            Guid tenantId,
            BankSlipReconciliationReprocessRequest request,
            CancellationToken cancellationToken);
    }
}
