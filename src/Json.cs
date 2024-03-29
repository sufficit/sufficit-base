﻿using Microsoft.Extensions.Options;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sufficit
{
    public static class Json
    {
        /// <summary>
        /// Use default json options
        /// </summary>
        public static JsonSerializerOptions Options { get; } = Generate();

        /// <summary>
        /// If you need an unmodified version
        /// </summary>
        /// <returns></returns>
        public static JsonSerializerOptions Generate()
        {
            var options = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,                
                AllowTrailingCommas = true,
                WriteIndented = false, 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
            };

            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, true));
            options.Converters.Add(new JsonStringTypeConverter());
            return options;
        }

        public class JsonStringTypeConverter : JsonConverter<Type>
        {
            public override Type? Read(
                ref Utf8JsonReader reader,
                Type _,
                JsonSerializerOptions __) => Type.GetType(reader.GetString()!);

            public override void Write(
                Utf8JsonWriter writer,
                Type type,
                JsonSerializerOptions _) => writer.WriteStringValue(type.ToString());
        }
    }
}
