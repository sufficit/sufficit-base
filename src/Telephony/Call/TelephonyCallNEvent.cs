using Sufficit.Notification;
using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Call
{
    /// <summary>
    ///     Asterisk Event for dial end
    /// </summary>
    [EventCollection]
    public class TelephonyCallNEvent : Event, IEvent
    {
        #region IMPLEMENT EVENT

        public const string EVENTID = "6c613723-2d1c-4b3e-9dcb-cc58fd13846a";
        public const string TITLE = "Atualização do estado de chamada telefônica";

        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public override Guid Id { get; } = Guid.Parse(EVENTID);

        [JsonPropertyOrder(0)]
        [JsonPropertyName("title")]
        public override string Title => TITLE;

        [JsonPropertyOrder(0)]
        [JsonPropertyName("method")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public override SubscribeMethod Method => SubscribeMethod.ByContextId;

        public override Guid? GetContextId() => Call.ContextId;

        #endregion

        [JsonPropertyOrder(1)]
        [JsonPropertyName("call")]
        public TelephonyCall Call { get; set; } = default!;
    }
}
