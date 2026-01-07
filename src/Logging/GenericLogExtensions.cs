using System;
using System.Text.Json;

namespace Sufficit.Logging
{
    public static class GenericLogExtensions
    {
        public static GenericLog<T> FromJsonLog<T>(this GenericLog<string> source, JsonSerializerOptions? options = null) where T : class
        {
            if (source is GenericLog<T> typedLog)
                return typedLog;

            return new GenericLog<T>()
            {
                Content = string.IsNullOrWhiteSpace(source.Content)
                    ? default
                    : JsonSerializer.Deserialize<T>(source.Content, options),
                ContextId = source.ContextId,
                ClassName = source.ClassName,
                Duration = source.Duration,
                Expiration = source.Expiration,
                Message = source.Message,
                Reference = source.Reference,
                Server = source.Server,
                Timestamp = source.Timestamp,
                UserId = source.UserId
            };
        }
    }
}