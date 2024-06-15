using Sufficit.Notification;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Event for dial out requests
    /// </summary>
    [EventCollection]
    public class DialOutNEvent : Event, IEvent
    {
        public const string EVENTID = "25515d2d-e749-47cf-8e51-220cd38f3a66";
        public const string TITLE = "Discagem externa";

        [JsonPropertyName("id")]
        public override Guid Id { get; } = Guid.Parse(EVENTID);

        [JsonPropertyName("title")]
        public override string Title => TITLE;              
    }
}
