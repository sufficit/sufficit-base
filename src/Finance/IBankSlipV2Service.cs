using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Defines the tenant-aware bank slip v2 application boundary.
    /// </summary>
    public interface IBankSlipV2Service
    {
        Task<BankSlipV2RequestResult> RequestAsync(
            Guid tenantId,
            Guid requestedBy,
            string idempotencyKey,
            BankSlipV2CreateRequest request,
            CancellationToken cancellationToken);

        Task<BankSlipV2PayerReadiness> GetPayerReadinessAsync(
            Guid tenantId,
            Guid contextId,
            string? provider,
            CancellationToken cancellationToken);

        Task<BankSlipV2View?> GetAsync(
            Guid tenantId,
            Guid bankSlipId,
            CancellationToken cancellationToken);

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

        Task<BankSlipV2SettingsView?> GetSettingsAsync(
            Guid tenantId,
            CancellationToken cancellationToken);

        Task<BankSlipV2SettingsView> UpdateSettingsAsync(
            Guid tenantId,
            Guid updatedBy,
            BankSlipV2SettingsUpdateRequest request,
            CancellationToken cancellationToken);

        Task<bool> SetPublicAccessAsync(
            Guid tenantId,
            Guid bankSlipId,
            bool enabled,
            Guid updatedBy,
            CancellationToken cancellationToken);

        Task<BankSlipV2View?> RequestRetryAsync(
            Guid tenantId,
            Guid bankSlipId,
            Guid requestedBy,
            CancellationToken cancellationToken);

        Task<BankSlipV2View?> RequestCancellationAsync(
            Guid tenantId,
            Guid bankSlipId,
            Guid requestedBy,
            CancellationToken cancellationToken);
    }
}
