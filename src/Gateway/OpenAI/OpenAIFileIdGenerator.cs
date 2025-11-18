using System;
using System.Security.Cryptography;
using System.Text;

namespace Sufficit.Gateway.OpenAI
{
    /// <summary>
    ///     Generates OpenAI-compatible file IDs
    ///     Format: file-{24 alphanumeric characters}
    /// </summary>
    public static class OpenAIFileIdGenerator
    {
        private const string PREFIX = "file-";
        private const int ID_LENGTH = 24;
        private const string CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        /// <summary>
        ///     Generate a new OpenAI-compatible file ID
        /// </summary>
        public static string Generate()
        {
            var sb = new StringBuilder(PREFIX, PREFIX.Length + ID_LENGTH);
            var bytes = new byte[ID_LENGTH];
            
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }

            for (int i = 0; i < ID_LENGTH; i++)
            {
                sb.Append(CHARS[bytes[i] % CHARS.Length]);
            }

            return sb.ToString();
        }

        /// <summary>
        ///     Validate if string is a valid OpenAI file ID format
        /// </summary>
        public static bool IsValid(string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
                return false;

            if (!fileId.StartsWith(PREFIX))
                return false;

            if (fileId.Length != PREFIX.Length + ID_LENGTH)
                return false;

            // Validate all characters after prefix are alphanumeric
            for (int i = PREFIX.Length; i < fileId.Length; i++)
            {
                if (!char.IsLetterOrDigit(fileId[i]))
                    return false;
            }

            return true;
        }

        /// <summary>
        ///     Extract the ID part without the "file-" prefix
        /// </summary>
        public static string GetIdWithoutPrefix(string fileId)
        {
            if (!IsValid(fileId))
                throw new ArgumentException($"Invalid OpenAI file ID format: {fileId}");

            return fileId.Substring(PREFIX.Length);
        }
    }
}
