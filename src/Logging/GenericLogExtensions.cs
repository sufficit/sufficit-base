using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Sufficit.Json;

namespace Sufficit.Logging
{
    public static class GenericLogExtensions
    {
        public static GenericLog<string> ToJsonLog<T>(this GenericLog<T> source, JsonSerializerOptions? options = null)
        {
            if (source is GenericLog<string> stringLog)
                return stringLog;

            return new GenericLog<string>()
            {
                Content = source.Content?.ToJson(options),
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

        public static GenericLog<T> FromJsonLog<T>(this GenericLog<string> source, JsonSerializerOptions? options = null)
        {
            if (source is GenericLog<T> typedLog)
                return typedLog;

            return new GenericLog<T>()
            {
                Content = source.Content.FromJson<T>(options),
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

        public static GenericLog<object?> FromJsonLog(this GenericLog<string> source, Type type, JsonSerializerOptions? options = null)
        {
            return new GenericLog<object?>()
            {
                Content = source.Content.FromJson(type, options),
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
