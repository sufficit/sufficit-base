using Sufficit.Exchange;
using Sufficit.Telephony;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Notification.Events
{
    public class DIDPropertiesUpdateEvent : DIDUpdateEvent
    {
        private readonly DirectInwardDialingProperties _props;

        public DIDPropertiesUpdateEvent(Guid id, DirectInwardDialingProperties properties) : base(id) 
        {
            _props = properties;
        }

        /*
        public override Task<string> GetBody(string? extra = null, TChannel channel = TChannel.UNKNOWN)
        {
            string message = "--------------------------------------------------------\r\n";
            message += $"*{Title}" + (!string.IsNullOrWhiteSpace(Queue) ? $" ({Queue})" : default) + "\r\n";
            message += $"Chave do evento (id): {Key}\r\n";
            message += $"Origem: { CallerIdNum }\r\n";
            message += $"Posição na fila: { Position }\r\n";
            message += $"Tempo de espera na fila: { HoldSeconds } segundos";

            return Task.FromResult(message);
        }
        */
    }
}
