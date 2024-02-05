using Sufficit.Notification;
using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Event for channels hangup
    /// </summary>
    [EventCollection]
    public class HangupNEvent : Event, IEvent
    {
        #region IMPLEMENT EVENT

        public const string EVENTID = "6c613723-2d1c-4b3e-9dcb-cc58fd13846a";
        public const string TITLE = "Desligamento de canal";

        [JsonPropertyName("id")]
        public override Guid Id { get; } = Guid.Parse(EVENTID);

        [JsonPropertyName("title")]
        public override string Title => TITLE;

        #endregion

        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ContextId { get; set; }

        [JsonPropertyName("key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Key { get; set; } = default!;

        [JsonPropertyName("channel")]
        public string Channel { get; set; } = default!;
               
        [JsonPropertyName("uniqueid")]
        public string UniqueId { get; set; } = default!;

        [JsonPropertyName("cause")]
        public string Cause { get; set; } = default!;

        [JsonPropertyName("server")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Server { get; set; }

        [JsonPropertyName("calleridnum")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? CallerIdNum { get; set; } = default!;

        [JsonPropertyName("calleridnume164")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? CallerIdNumE164 { get; set; } = default!;

        [JsonPropertyName("connectedlinenum")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? ConnectedLineNum { get; set; } = default!;

        public override string GetKey() => Key;
    }
}
