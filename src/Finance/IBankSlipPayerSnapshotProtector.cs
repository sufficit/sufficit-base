using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Protects payer data at rest while binding it to one tenant, context and bank slip.
    /// </summary>
    public interface IBankSlipPayerSnapshotProtector
    {
        Task<ProtectedBankSlipPayerSnapshot> ProtectAsync(
            Guid tenantId,
            Guid contextId,
            Guid bankSlipId,
            BankSlipPayerSnapshot snapshot,
            CancellationToken cancellationToken);

        Task<BankSlipPayerSnapshot> UnprotectAsync(
            Guid tenantId,
            Guid contextId,
            Guid bankSlipId,
            byte[] payload,
            string keyId,
            CancellationToken cancellationToken);
    }
}
