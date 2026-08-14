using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Provider boundary for callbacks that carry their complete event in the
    /// request body. Authentication and JSON interpretation remain owned by
    /// the provider gateway; the application receives only a neutral envelope.
    /// </summary>
    public interface IBankSlipProviderWebhookGateway
    {
        string ProviderCode { get; }

        Task<bool> AuthenticateWebhookAsync(
            IReadOnlyDictionary<string, string> requestHeaders,
            BankSlipGatewayContext context,
            CancellationToken cancellationToken);

        BankSlipProviderWebhookEnvelope ParseWebhook(string requestPayload);
    }

    /// <summary>
    /// Minimal provider-neutral envelope required to durably enqueue a webhook.
    /// </summary>
    public sealed class BankSlipProviderWebhookEnvelope
    {
        public string NotificationId { get; set; } = string.Empty;
        public Guid BankSlipId { get; set; }
        public BankSlipProviderNotificationBatch Batch { get; set; } = new();
    }
}
