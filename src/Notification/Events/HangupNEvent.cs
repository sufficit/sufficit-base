using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Notification.Events
{
    /// <summary>
    /// Event for channels hangup
    /// </summary>
    [EventCollection]
    public class HangupNEvent : Event, IEvent
    {
        #region IMPLEMENT EVENT

        public override Guid Id { get; } = Guid.Parse(IDEVENT);

        public override string Title => TITLE;

        public const string IDEVENT = "6c613723-2d1c-4b3e-9dcb-cc58fd13846a";
        public const string TITLE = "Desligamento de canal";

        #endregion

        public Guid ContextId { get; set; }

        public string Key { get; set; } = default!;

        public string Cause { get; set; } = default!;

        public string? CallerIdNum { get; set; } = default!;

        [JsonIgnore]
        public string? CallerIdNumFormatted { get; set; } = default!;

        public override string GetKey() => Key;

        public override Task<string> GetBody(string? extra = null, TChannel channel = TChannel.UNKNOWN)
        {
            string message = "--------------------------------------------------------\r\n";
            message += $"*{Title}\r\n";
            message += $"Chave do evento (id): {Key}\r\n";
            message += $"Id do contexto: {ContextId}\r\n"; 
            message += $"Origem: {CallerIdNumFormatted}\r\n";

            return Task.FromResult(message);
        }
    }
}
