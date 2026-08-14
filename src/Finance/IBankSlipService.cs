using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Defines the tenant-aware bank-slip application boundary.
    /// </summary>
    public interface IBankSlipService
    {
        Task<BankSlipRequestResult> RequestAsync(
            Guid tenantId,
            Guid requestedBy,
            string idempotencyKey,
            BankSlipCreateRequest request,
            CancellationToken cancellationToken);

        Task<BankSlipPayerReadiness> GetPayerReadinessAsync(
            Guid tenantId,
            Guid contextId,
            string? provider,
            CancellationToken cancellationToken);

        Task<BankSlipView?> GetAsync(
            Guid tenantId,
            Guid bankSlipId,
            CancellationToken cancellationToken);

        Task<BankSlipSearchResult> SearchAsync(
            Guid tenantId,
            BankSlipSearchParameters parameters,
            CancellationToken cancellationToken);

        Task<BankSlipStatistics> GetStatisticsAsync(
            Guid tenantId,
            BankSlipStatisticsParameters parameters,
            CancellationToken cancellationToken);

        Task<IReadOnlyList<BankSlipChange>> GetChangesAsync(
            Guid tenantId,
            DateTime updatedSinceUtc,
            int limit,
            CancellationToken cancellationToken);

        Task<BankSlipPublicDocumentSource?> GetPublicDocumentSourceAsync(
            Guid tenantId,
            Guid contextId,
            Guid bankSlipId,
            CancellationToken cancellationToken);

        Task<BankSlipSettingsView?> GetSettingsAsync(
            Guid tenantId,
            CancellationToken cancellationToken);

        Task<BankSlipSettingsView> UpdateSettingsAsync(
            Guid tenantId,
            Guid updatedBy,
            BankSlipSettingsUpdateRequest request,
            CancellationToken cancellationToken);

        Task<bool> SetPublicAccessAsync(
            Guid tenantId,
            Guid bankSlipId,
            bool enabled,
            Guid updatedBy,
            CancellationToken cancellationToken);

        Task<BankSlipView?> RequestRetryAsync(
            Guid tenantId,
            Guid bankSlipId,
            Guid requestedBy,
            CancellationToken cancellationToken);

        Task<BankSlipView?> RequestCancellationAsync(
            Guid tenantId,
            Guid bankSlipId,
            Guid requestedBy,
            CancellationToken cancellationToken);
    }
}
