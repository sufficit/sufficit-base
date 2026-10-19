using System;
using Sufficit.Notification;
using Sufficit.Exchange;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>Reserved subscription identity for provider-managed fiscal recipients. Never dispatched.</summary>
    public sealed class InvoiceRecipientsVirtualEvent : NotificationEvent
    {
        public static readonly Guid EventId = new Guid("b356d659-2f40-49a8-87ca-d7556aadf3c0");
        public override Guid Id => EventId;
        public override string Title => "Destinatários fiscais (envio pelo provedor)";
        public override SubscribeMethod Method => SubscribeMethod.ByKeyAndContextId;
        public override ValueTask<string> GetBody(string? extra = null, TChannel channel = default)
            => throw new InvalidOperationException("Virtual fiscal subscriptions cannot generate messages.");
    }

    public sealed class InvoiceRecipientSettings
    {
        public Guid InvoiceId { get; set; }
        public Guid ContextId { get; set; }
        public string Provider { get; set; } = "ASAAS";
        public string CustomerId { get; set; } = string.Empty;
        public string Environment { get; set; } = string.Empty;
        public bool Configured { get; set; }
        public string PrimaryEmail { get; set; } = string.Empty;
        public string[] AdditionalEmails { get; set; } = Array.Empty<string>();
        public string RemotePrimaryEmail { get; set; } = string.Empty;
        public string[] RemoteAdditionalEmails { get; set; } = Array.Empty<string>();
        public string Revision { get; set; } = string.Empty;
        public bool Synchronized { get; set; }
        public string? SynchronizationError { get; set; }
    }

    public sealed class InvoiceRecipientUpdate
    {
        public string Revision { get; set; } = string.Empty;
        public string PrimaryEmail { get; set; } = string.Empty;
        public string[] AdditionalEmails { get; set; } = Array.Empty<string>();
    }
}
