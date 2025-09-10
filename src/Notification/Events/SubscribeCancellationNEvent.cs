using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sufficit.Exchange;

namespace Sufficit.Notification.Events
{
    /// <summary>
    /// Event for dialplans updates
    /// </summary>
    [NotificationEventCollection]
    public class SubscribeCancellationNEvent : NotificationEvent, INotificationEvent
    {
        #region IMPLEMENT EVENT

        public override Guid Id { get; } = Guid.Parse(IDEVENT);

        public override string Title => TITLE;

        #endregion

        public const string IDEVENT = "a4b5e8e1-2d3c-4f0c-9f2e-2e3f4b5c6d7e";
        public const string TITLE = "Evento de cancelamento de assinatura em notificações";

        public override Guid? GetReferenceId()
            => MessageId;

        public Guid MessageId { get; set; }

        public string? ClientIP { get; set; }

        public string? UserAgent { get; set; }

        public string? ProxyInfo { get; set; }

        public override ValueTask<string> GetBody(string? extra = null, TChannel channel = TChannel.UNKNOWN)
        {
            // for webhook must be a valid json
            if (channel == TChannel.WEBHOOK)
                return base.GetBody(extra, channel);

            string message = "--------------------------------------------------------\r\n";
            message += $"*{Title}\r\n";
            message += $"Chave do evento (id): {this.GetKey()}\r\n";
            message += $"ID da mensagem: {MessageId}\r\n";
            message += $"IP do cliente: {ClientIP}\r\n";
            message += $"User Agent: {UserAgent}\r\n";            
            message += $"Data/Hora: {Timestamp}\r\n";
            message += $"Informações de Proxy/Roteamento:\r\n";
            message += ProxyInfo;          

            return new ValueTask<string>(message);
        }
    }
}
