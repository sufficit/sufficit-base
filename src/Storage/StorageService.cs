﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Storage
{
    public enum StorageService
    {
        [EnumMember(Value = "local")]
        LOCAL,

        [EnumMember(Value = "gcloud")]
        GOOGLE_CLOUD,

        [EnumMember(Value = "aws")]
        AWS_S3,

        /// <summary>
        ///     The HTTP is a direct link (url) to the file, not a storage service
        /// </summary>
        [EnumMember(Value = "http")]
        HTTP,
    }
}
