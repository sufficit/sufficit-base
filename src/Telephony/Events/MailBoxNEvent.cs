using Sufficit.Notification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Events
{
    [EventCollection]
    public class MailBoxNEvent : Event, IEvent
    {
        #region IMPLEMENT EVENT

        [JsonPropertyName("id")]
        public override Guid Id { get; } = Guid.Parse(IDEVENT);

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public override string Title => TITLE;

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public const string IDEVENT = "69f367ab-c465-4f29-991f-b31b0b8e0760";

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public const string TITLE = "Caixa Postal";

        #endregion

        public override string GetKey()
            => MBAddress;

        public Guid? ContextId { get; set; }
        public override Guid? GetContextId()
            => ContextId;

        public Guid? ReferenceId { get; set; }
        public override Guid? GetReferenceId()
            => ReferenceId;

        /// <summary>
        /// Voice Mail address that trigger the event
        /// </summary>
        [JsonPropertyName("mbaddress")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string MBAddress { get; set; } = default!;

        /// <summary>
        /// Voice Mail title that trigger the event
        /// </summary>
        [JsonPropertyName("mbtitle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? MBTitle { get; set; }

        /// <summary>
        /// Endereço de e-mail que veio no cabecalho da msg
        /// </summary>

        [JsonPropertyName("originaldestination")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? OriginalDestination { get; set; }


        [JsonPropertyName("originalsource")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? OriginalSource { get; set; }

        [JsonPropertyName("source")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Source { get; set; }

        [JsonPropertyName("originaldate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime OriginalDate { get; set; }

        [JsonPropertyName("date")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Date { get; set; }

        [JsonPropertyName("transcript")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Transcript { get; set; }

        [JsonPropertyName("totaltime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int TotalTime { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public byte[]? MP3Body { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public byte[]? WavBody { get; set; }
    }
}
