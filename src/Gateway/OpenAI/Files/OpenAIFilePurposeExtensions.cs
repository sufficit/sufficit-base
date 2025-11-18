using Sufficit.Storage;
using System;

namespace Sufficit.Gateway.OpenAI.Files
{
    /// <summary>
    ///     Extension methods for OpenAI File Purpose conversion
    /// </summary>
    public static class OpenAIFilePurposeExtensions
    {
        /// <summary>
        ///     Convert OpenAI Purpose string to StorageSection enum
        /// </summary>
        public static StorageSection ToStorageSection(this string purpose)
        {
            return purpose?.ToLowerInvariant() switch
            {
                "assistants" => StorageSection.Assistants,
                "fine-tune" => StorageSection.FineTune,
                "batch" => StorageSection.Batch,
                "vision" => StorageSection.Vision,
                _ => throw new ArgumentException($"Invalid OpenAI file purpose: {purpose}")
            };
        }

        /// <summary>
        ///     Check if string is a valid OpenAI purpose
        /// </summary>
        public static bool IsOpenAIPurpose(this string? purpose)
        {
            if (string.IsNullOrWhiteSpace(purpose))
                return false;

            var normalized = purpose.ToLowerInvariant();
            return normalized == "assistants"
                || normalized == "fine-tune"
                || normalized == "batch"
                || normalized == "vision";
        }

        /// <summary>
        ///     Convert OpenAI Purpose enum to StorageSection enum
        /// </summary>
        public static StorageSection ToStorageSection(this OpenAIFilePurpose purpose)
        {
            return purpose switch
            {
                OpenAIFilePurpose.Assistants => StorageSection.Assistants,
                OpenAIFilePurpose.FineTune => StorageSection.FineTune,
                OpenAIFilePurpose.Batch => StorageSection.Batch,
                OpenAIFilePurpose.Vision => StorageSection.Vision,
                _ => throw new ArgumentException($"Invalid OpenAI file purpose: {purpose}")
            };
        }

        /// <summary>
        ///     Convert StorageSection enum to OpenAI Purpose string
        /// </summary>
        public static string ToOpenAIPurpose(this StorageSection section)
        {
            return section switch
            {
                StorageSection.Assistants => "assistants",
                StorageSection.FineTune => "fine-tune",
                StorageSection.Batch => "batch",
                StorageSection.Vision => "vision",
                _ => throw new ArgumentException($"StorageSection {section} is not a valid OpenAI file purpose")
            };
        }

        /// <summary>
        ///     Check if StorageSection is a valid OpenAI purpose
        /// </summary>
        public static bool IsOpenAIPurpose(this StorageSection section)
        {
            return section == StorageSection.Assistants
                || section == StorageSection.FineTune
                || section == StorageSection.Batch
                || section == StorageSection.Vision;
        }
    }
}
