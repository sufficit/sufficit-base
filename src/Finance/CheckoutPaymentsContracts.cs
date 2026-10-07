using System;
using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    /// Wire contracts for the private Asaas checkout payments surface exposed
    /// by the Sufficit API. They speak checkout vocabulary only; gateway types
    /// never cross the API boundary.
    /// </summary>
    public sealed class CheckoutPaymentCreateRequest
    {
        public Guid PaymentId { get; set; }
        public Guid ContextId { get; set; }
        public decimal Value { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; } = string.Empty;

        /// <summary>"pix", "bankslip" or "card" (case-insensitive).</summary>
        public string Method { get; set; } = "pix";

        /// <summary>Validated Sufficit checkout URL for returning from a hosted card payment.</summary>
        public string? CardReturnUrl { get; set; }

        public CheckoutPaymentPayerRequest Payer { get; set; }
    }

    public sealed class CheckoutPaymentPayerRequest
    {
        public string ProviderCustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Email { get; set; }
    }

    public sealed class CheckoutPaymentView
    {
        public string ProviderCode { get; set; } = string.Empty;
        public string ChargeId { get; set; } = string.Empty;
        public string ProviderStatus { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string CopyAndPaste { get; set; }
        public string QrCodeImageDataUri { get; set; }
        public DateTimeOffset? ExpiresAt { get; set; }
        public string IdentificationField { get; set; }
        public string BarCode { get; set; }
        /// <summary>Validated HTTPS payment page hosted by Asaas for card charges.</summary>
        public string? RedirectUrl { get; set; }
    }

    /// <summary>Transient card payment request for an already reserved checkout charge.</summary>
    public sealed class CheckoutCardPayRequest
    {
        public Guid IntentId { get; set; }
        public Guid SessionId { get; set; }
        public string ChargeId { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public CheckoutCardDetails Card { get; set; } = new();
        public CheckoutCardholderDetails Holder { get; set; } = new();
    }

    public sealed class CheckoutCardDetails
    {
        public string HolderName { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string ExpiryMonth { get; set; } = string.Empty;
        public string ExpiryYear { get; set; } = string.Empty;
        public string Ccv { get; set; } = string.Empty;
    }

    public sealed class CheckoutCardholderDetails
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string AddressNumber { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }

    public sealed class CheckoutCardPayView
    {
        public string ChargeId { get; set; } = string.Empty;
        public string ProviderStatus { get; set; } = string.Empty;
    }

    public sealed class CheckoutAccountView
    {
        public string Document { get; set; } = string.Empty;
        public string CompanyName { get; set; }
        public string PersonType { get; set; }
        public string Status { get; set; }
    }

    public sealed class CheckoutWebhookProvisioningRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string NotificationEmail { get; set; } = string.Empty;
        public bool Enabled { get; set; } = true;
        public bool ForceUpdate { get; set; }
        public IReadOnlyCollection<string> Events { get; set; } = Array.Empty<string>();
    }

    public sealed class CheckoutWebhookSubscriptionView
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; }
        public string NotificationEmail { get; set; }
        public bool Enabled { get; set; }
        public bool Interrupted { get; set; }
        public string SendType { get; set; } = string.Empty;
        public IReadOnlyCollection<string> Events { get; set; } = Array.Empty<string>();
    }

    public sealed class CheckoutWebhookProvisioningView
    {
        public string Outcome { get; set; } = string.Empty;
        public CheckoutWebhookSubscriptionView Subscription { get; set; }
    }

    public sealed class CheckoutWebhookVerifyRequest
    {
        public IReadOnlyDictionary<string, string> Headers { get; set; }
        public string Payload { get; set; } = string.Empty;
    }

    public sealed class CheckoutWebhookNotificationView
    {
        public string EventId { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
        public DateTimeOffset? EventAt { get; set; }
        public string ChargeId { get; set; } = string.Empty;
        public string ProviderStatus { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ExternalReference { get; set; }
        public DateTimeOffset? PaidAt { get; set; }
        public decimal? Value { get; set; }
    }

    public sealed class CheckoutWebhookVerificationView
    {
        public bool TestPayment { get; set; }
        public bool Authenticated { get; set; }
        public CheckoutWebhookNotificationView Notification { get; set; }
    }
}
