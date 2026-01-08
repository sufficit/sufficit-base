using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sufficit.Json;

namespace Sufficit
{
    /// <summary>
    /// JSON converter that handles both TagFilter objects and string inputs
    /// </summary>
    [AutoRegisterConverter]
    public class TagFilterConverter : JsonConverter<TagFilter?>
    {
        public override TagFilter? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString();
                return (TagFilter)stringValue!; // Uses implicit conversion
            }

            // Handle object deserialization
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                // avoids infinite loop
                var _options = new JsonSerializerOptions(options);
                _options.Converters.Remove(this);

                return System.Text.Json.JsonSerializer.Deserialize<TagFilter?>(ref reader, _options);
            }

            throw new System.Text.Json.JsonException($"Unexpected token type {reader.TokenType} for TagFilter");
        }

        public override void Write(Utf8JsonWriter writer, TagFilter? value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            // avoids infinite loop
            var _options = new JsonSerializerOptions(options);
            _options.Converters.Remove(this);

            System.Text.Json.JsonSerializer.Serialize(writer, value, _options);
        }
    }
}