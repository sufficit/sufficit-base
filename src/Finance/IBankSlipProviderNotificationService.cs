using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Application boundary for receiving, processing and inspecting provider callbacks.
    /// </summary>
    public interface IBankSlipProviderNotificationService
    {
        Task<BankSlipProviderNotificationReceiptResult> ReceiveAsync(
            Guid tenantId,
            Guid bankSlipId,
            string provider,
            string notificationToken,
            string requestPayload,
            CancellationToken cancellationToken);

        Task<int> ProcessPendingAsync(
            int batchSize,
            CancellationToken cancellationToken);

        Task<IReadOnlyList<BankSlipProviderNotificationView>> GetHistoryAsync(
            Guid tenantId,
            Guid? bankSlipId,
            string? provider,
            int limit,
            CancellationToken cancellationToken);
    }
}
