using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Storage
{
    public enum StorageSection
    {
        [EnumMember(Value = "user")]
        User,

        [EnumMember(Value = "invoice")]
        Invoice,
    }
}
