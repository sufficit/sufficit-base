using Sufficit.Notification;
using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Events
{
    /// <summary>
    /// Published when a voicemail mailbox is automatically disabled by the mailbox-worker
    /// after sustained delivery failures (no valid contacts for dispatch).
    /// Intended for operator alerting so they can investigate and manually re-enable the mailbox.
    /// </summary>
    [NotificationEventCollection]
    public class VoiceMailBoxAutoDisabledEvent : NotificationEvent, INotificationEvent
    {
        #region IMPLEMENT EVENT

        [JsonPropertyName("id")]
        public override Guid Id { get; } = Guid.Parse(IDEVENT);

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public override string Title => TITLE;

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public const string IDEVENT = "8b3d4e5f-6a7c-4d8e-9f0a-1b2c3d4e5f6a";

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public const string TITLE = "Caixa Postal Auto-Desabilitada";

        #endregion

        public override string GetKey()
            => BoxId.ToString("N");

        public Guid? ContextId { get; set; }
        public override Guid? GetContextId()
            => ContextId;

        public override Guid? GetReferenceId()
            => BoxId;

        /// <summary>
        /// VoiceMailBox.Id of the disabled mailbox.
        /// </summary>
        [JsonPropertyName("boxId")]
        public Guid BoxId { get; set; }

        /// <summary>
        /// VoiceMailBox.Title (business key within the context).
        /// </summary>
        [JsonPropertyName("boxTitle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BoxTitle { get; set; }

        /// <summary>
        /// Reason for auto-disable (e.g., "no_valid_contact_24h").
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; } = default!;

        /// <summary>
        /// UTC timestamp when the mailbox was disabled.
        /// </summary>
        [JsonPropertyName("disabledAt")]
        public DateTime DisabledAt { get; set; }

        /// <summary>
        /// Duration of the failure window in hours (typically 24).
        /// </summary>
        [JsonPropertyName("windowHours")]
        public int WindowHours { get; set; }
    }
}
