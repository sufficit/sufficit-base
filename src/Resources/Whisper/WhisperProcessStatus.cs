using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Resources.Whisper
{
    public enum WhisperProcessStatus
    {
        [EnumMember(Value = "accepted")]
        Accepted = 0,

        [EnumMember(Value = "enqueued")]
        Enqueued,

        [EnumMember(Value = "running")]
        Running,

        [EnumMember(Value = "finished")]
        Finished
    }
}
