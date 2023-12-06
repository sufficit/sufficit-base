using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Notification.Events
{
    /// <summary>
    /// Event for queue abandons
    /// </summary>
    [EventCollection]
    public class QueueAbandonNEvent : Event, IEvent
    {
        #region IMPLEMENT EVENT

        public override Guid Id { get; } = Guid.Parse(IDEVENT);

        public override string Title => TITLE;

        public const string IDEVENT = "6571680f-7017-4f6c-98dc-23fce63bd731";
        public const string TITLE = "Abandono de fila de espera";

        #endregion

        public string Key { get; set; } = default!;

        public string Queue { get; set; } = default!;

        public string CallerIdNum { get; set; } = default!;

        public int Position { get; set; }

        public int HoldSeconds { get; set; }

        public override string GetKey() => Key;

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
    }
}
