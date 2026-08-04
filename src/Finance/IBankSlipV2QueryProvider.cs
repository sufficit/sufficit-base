using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Defines the persistence boundary for bank slip v2 operational queries.
    /// </summary>
    public interface IBankSlipV2QueryProvider
    {
        Task<BankSlipV2SearchResult> SearchAsync(
            Guid tenantId,
            BankSlipV2SearchParameters parameters,
            CancellationToken cancellationToken);

        Task<BankSlipV2Statistics> GetStatisticsAsync(
            Guid tenantId,
            BankSlipV2StatisticsParameters parameters,
            CancellationToken cancellationToken);

        Task<IReadOnlyList<BankSlipV2Change>> GetChangesAsync(
            Guid tenantId,
            DateTime updatedSinceUtc,
            int limit,
            CancellationToken cancellationToken);

        Task<BankSlipV2PublicDocumentSource?> GetPublicDocumentSourceAsync(
            Guid tenantId,
            Guid contextId,
            Guid bankSlipId,
            CancellationToken cancellationToken);
    }
}
