using Sufficit.Exchange;
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
        #region IMPLEMENT EVENT

        public const string EVENTID = "25515d2d-e749-47cf-8e51-220cd38f3a66";
        public const string TITLE = "Discagem externa";

        [JsonPropertyName("id")]
        public override Guid Id { get; } = Guid.Parse(EVENTID);

        [JsonPropertyName("title")]
        public override string Title => TITLE;

        #endregion

        [JsonPropertyName("key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Key { get; set; } = default!;

        [JsonPropertyName("channel")]
        public string Channel { get; set; } = default!;

        [JsonPropertyName("extensionid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ExtensionId { get; set; }

        /// <summary>
        ///     Outbound provider id for billing purposes
        /// </summary>
        [JsonPropertyName("providerid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ProviderId { get; set; }

        /// <summary>
        /// Dialed number identifier
        /// </summary>
        [JsonPropertyName("dnid")]
        public string Dnid { get; set; } = default!;

        [JsonPropertyName("uniqueid")]
        public string UniqueId { get; set; } = default!;

        [JsonPropertyName("destination")]
        public string Destination { get; set; } = default!;

        [JsonPropertyName("server")]
        public string Server { get; set; } = default!;

        [JsonPropertyName("calleridnum")]
        public string? CallerIdNum { get; set; } = default!;

        /// <summary>
        /// Discagem encaminha a informação da BINA ?
        /// </summary>
        [JsonPropertyName("idforward")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public IdForwardPreference IdForward { get; set; }

        [JsonPropertyName("alternative")]
        public bool Alternative { get; set; }

        public override string GetKey() => Key;
    }
}
