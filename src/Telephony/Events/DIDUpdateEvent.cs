using Sufficit.Exchange;
using Sufficit.Telephony;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Notification.Events
{
    public class DIDUpdateEvent : Event
    {
        #region IMPLEMENT EVENT

        public override Guid ID => Guid.Parse(IDEVENT);

        public override string Title => TITLE;

        public const string IDEVENT = "ffb1654e-644a-4f88-a223-13900a042b4a";
        public const string TITLE = "Atualização de rota de entrada";

        #endregion

        public DIDUpdateEvent(Guid id)
        {
            DIDId = id;
        }

        public virtual Guid DIDId { get; } 

        public override string GetKey() => DIDId.ToString();

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
