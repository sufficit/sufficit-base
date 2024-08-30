using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Resources.Whisper
{
    public enum WhisperProcessStatus
    {
        Accepted = 0,
        Enqueued,
        Running,
        Finished
    }
}
