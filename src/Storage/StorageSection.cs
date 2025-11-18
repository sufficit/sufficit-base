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

        /// <summary>
        ///     OpenAI Files API - Assistants purpose
        /// </summary>
        [EnumMember(Value = "assistants")]
        Assistants,

        /// <summary>
        ///     OpenAI Files API - Fine-tuning purpose
        /// </summary>
        [EnumMember(Value = "fine-tune")]
        FineTune,

        /// <summary>
        ///     OpenAI Files API - Batch processing purpose
        /// </summary>
        [EnumMember(Value = "batch")]
        Batch,

        /// <summary>
        ///     OpenAI Files API - Vision/image analysis purpose
        /// </summary>
        [EnumMember(Value = "vision")]
        Vision,
    }
}
