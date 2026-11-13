using System.Text.Json.Serialization;

namespace Sufficit.Notification
{
    /// <summary>
    ///     How a notification body is presented to a contact.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NotificationFormat
    {
        /// <summary>Human-readable text, formatted per channel (default).</summary>
        TEXT = 0,

        /// <summary>Structured JSON document, for automated consumers.</summary>
        JSON = 1,
    }
}
