using Sufficit.Gateway;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{

    /// <summary>
    /// Provider-neutral boundary for creating a Pix charge and presenting its
    /// payment artifact inside a Sufficit-owned experience.
    /// </summary>
    public interface IPixPaymentGateway
    {
        string ProviderCode { get; }

        Task<PixPaymentResult> CreateAsync(
            PixPaymentRequest request,
            GatewayCallContext context,
            CancellationToken cancellationToken);

        Task<PixPaymentResult?> GetAsync(
            string providerChargeId,
            GatewayCallContext context,
            CancellationToken cancellationToken);

        Task<bool> AuthenticateWebhookAsync(
            IReadOnlyDictionary<string, string> requestHeaders,
            GatewayCallContext context,
            CancellationToken cancellationToken);

        PixPaymentNotification ParseWebhook(string requestPayload);
    }

    public sealed class PixPaymentRequest
    {
        public Guid PaymentId { get; set; }
        public Guid ContextId { get; set; }
        public decimal Value { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public PixPaymentPayer Payer { get; set; } = new();
    }

    /// <summary>
    /// The provider customer id may be supplied by a protected server-side
    /// mapping. Otherwise the gateway resolves or creates a customer from the
    /// payer snapshot. This object must never be serialized into a public URL.
    /// </summary>
    public sealed class PixPaymentPayer
    {
        public string? ProviderCustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public sealed class PixPaymentResult
    {
        public string ProviderCode { get; set; } = string.Empty;
        public string ChargeId { get; set; } = string.Empty;
        public string ProviderStatus { get; set; } = string.Empty;
        public PixPaymentStatus Status { get; set; }
        public string? CopyAndPaste { get; set; }
        public string? QrCodeImageDataUri { get; set; }
        public DateTimeOffset? ExpiresAt { get; set; }
    }

    public sealed class PixPaymentNotification
    {
        public string EventId { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
        public DateTimeOffset? EventAt { get; set; }
        public string ChargeId { get; set; } = string.Empty;
        public string ProviderStatus { get; set; } = string.Empty;
        public PixPaymentStatus Status { get; set; }
        public string? ExternalReference { get; set; }
        public DateTimeOffset? PaidAt { get; set; }
        public decimal? Value { get; set; }
    }

    public enum PixPaymentStatus : byte
    {
        AwaitingPayment = 0,
        Paid = 1,
        Expired = 2,
        Canceled = 3,
        Refunded = 4,
        Processing = 5,
        Unknown = 255
    }
}
