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
            var namingPolicy = JsonNamingPolicy.CamelCase;

            var options = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,                
                AllowTrailingCommas = true,
                WriteIndented = false, 
                PropertyNamingPolicy = namingPolicy,
                PropertyNameCaseInsensitive = true,
            };

            options.Converters.Add(new JsonStringEnumConverter(namingPolicy, true));
            options.Converters.Add(new JsonStringTypeConverter());
            return options;
        }
    }
}
