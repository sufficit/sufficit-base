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

        /// <summary>
        /// Durably receives a token-only callback emitted for a charge created
        /// by the legacy system. The aggregate identity is resolved later from
        /// the immutable provider history and bound to the migrated MySQL row.
        /// </summary>
        Task<BankSlipProviderNotificationReceiptResult> ReceiveLegacyAsync(
            Guid tenantId,
            string provider,
            string notificationToken,
            string requestPayload,
            CancellationToken cancellationToken);

        /// <summary>
        /// Authenticates and durably receives a provider webhook whose event
        /// identity and target aggregate are carried by the JSON payload.
        /// Provider-specific headers and payload interpretation stay inside
        /// the provider gateway.
        /// </summary>
        Task<BankSlipProviderNotificationReceiptResult> ReceiveWebhookAsync(
            Guid tenantId,
            string provider,
            IReadOnlyDictionary<string, string> requestHeaders,
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
