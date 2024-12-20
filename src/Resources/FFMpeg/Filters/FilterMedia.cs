using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Resources.FFMpeg.Filters
{
    public enum FilterMedia
    {
        [EnumMember(Value = "a")]
        AUDIO,

        [EnumMember(Value = "v")]
        VIDEO
    }
}
