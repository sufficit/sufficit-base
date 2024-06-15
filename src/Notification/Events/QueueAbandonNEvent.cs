using Sufficit.Exchange;
using Sufficit.Telephony;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Notification.Events
{
    /// <summary>
    /// Event for queue abandons
    /// </summary>
    [EventCollection]
    public class QueueAbandonNEvent : Event, IEvent
    {
        /// <summary>
        ///     Used for Event Collection or Testing porpouses
        /// </summary>
        public QueueAbandonNEvent() => Queue = new CallQueue();

        public QueueAbandonNEvent(CallQueue source) => Queue = source;

        #region IMPLEMENT EVENT

        public override Guid Id { get; } = Guid.Parse(IDEVENT);

        public override string Title => TITLE;

        public const string IDEVENT = "6571680f-7017-4f6c-98dc-23fce63bd731";
        public const string TITLE = "Abandono de fila de espera";

        #endregion

        public override string? GetKey()
            => Queue.Id.ToString("N");

        public override Guid? GetContextId()
            => Queue.ContextId;

        public override Guid? GetReferenceId()
            => Queue.Id;

        public CallQueue Queue { get; set; }

        [JsonPropertyName("calleridnum")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? CallerIdNum { get; set; }

        public int Position { get; set; }

        public int HoldSeconds { get; set; }

        public override ValueTask<string> GetBody(string? extra = null, TChannel channel = TChannel.UNKNOWN)
        {
            // for webhook must be a valid json
            if (channel == TChannel.WEBHOOK)
                return base.GetBody(extra, channel);

            string message = "--------------------------------------------------------\r\n";
            message += $"*{Title})\r\n";
            message += $"Chave do evento (id): {this.GetKey()}\r\n";

            message += $"Título (fila): {Queue.Title}\r\n";
            if (Queue.Extension?.StartsWith("00") ?? false && Queue.Extension.Length > 6)
                message += $"Extensão (fila): {Queue.Extension.Substring(6)}\r\n";

            message += $"Origem: {CallerIdNum}\r\n";
            message += $"Posição na fila: {Position}\r\n";
            message += $"Tempo de espera na fila: {HoldSeconds} segundos";

            return new ValueTask<string>(message);
        }
    }
}
