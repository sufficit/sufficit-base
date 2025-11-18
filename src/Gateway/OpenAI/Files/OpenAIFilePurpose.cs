using System.Runtime.Serialization;

namespace Sufficit.Gateway.OpenAI.Files
{
    /// <summary>
    ///     OpenAI File Purpose
    ///     Maps to Sufficit.Storage.StorageSection
    /// </summary>
    public enum OpenAIFilePurpose
    {
        [EnumMember(Value = "assistants")]
        Assistants,

        [EnumMember(Value = "fine-tune")]
        FineTune,

        [EnumMember(Value = "batch")]
        Batch,

        [EnumMember(Value = "vision")]
        Vision,
    }
}
