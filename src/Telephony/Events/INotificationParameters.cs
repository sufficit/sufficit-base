using System.Collections.Generic;

namespace Sufficit.Telephony.Events
{
    /// <summary>
    /// Optional public notification metadata supplied by applications.
    /// Keys are stable application identifiers; values are plain text, never markup or secrets.
    /// These parameters cannot replace the event's identity or delivery recipients.
    /// </summary>
    public interface INotificationParameters
    {
        IDictionary<string, string>? Parameters { get; set; }
    }
}
