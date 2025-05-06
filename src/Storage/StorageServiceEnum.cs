using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Storage
{
    public enum StorageServiceEnum
    {
        [EnumMember(Value = "local")]
        LOCAL,

        [EnumMember(Value = "gcloud")]
        GOOGLE_CLOUD,

        [EnumMember(Value = "aws")]
        AWS_S3,
    }
}
