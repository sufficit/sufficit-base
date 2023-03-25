using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sufficit.Telephony
{
    public enum CallRecordingSection
    {
        [Description("monitor")]
        MONITOR,

        [Description("voicemail")]
        VOICEMAIL
    }
}
