using System;

namespace Sufficit.Telephony
{
    /// <summary>Turns call recording on or off for one extension of a customer context.</summary>
    public class EndPointRecordingChange
    {
        public Guid ContextId { get; set; }
        public Guid EndPointId { get; set; }
        public bool Enabled { get; set; }
    }
}
