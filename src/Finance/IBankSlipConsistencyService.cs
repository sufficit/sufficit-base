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
    }
}
