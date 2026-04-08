using System;

namespace Sufficit.Telephony.InterConnection
{
    public class InterconnectionTestCallProgressEntry
    {
        public DateTime TimestampUtc { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string? Details { get; set; }

        public InterconnectionTestCallProgressKind Kind { get; set; } = InterconnectionTestCallProgressKind.Info;
    }

    public enum InterconnectionTestCallProgressKind
    {
        Info = 0,
        Success = 1,
        Warning = 2,
        Error = 3,
    }
}
