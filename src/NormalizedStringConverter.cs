using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sufficit.Json;

namespace Sufficit
{
    [AutoRegisterConverter]
    public class NormalizedStringConverter : JsonConverter<NormalizedString>
    {
        public override NormalizedString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return new NormalizedString(null);

            if (reader.TokenType == JsonTokenType.String)
            {
                // reads parsed data as string
                string? value = reader.GetString();

                // convert to NormalizedString
                return new NormalizedString(value);
            }

            throw new System.Text.Json.JsonException($"Unexpected token type {reader.TokenType} when parsing NormalizedString");
        }

        public override void Write(Utf8JsonWriter writer, NormalizedString value, JsonSerializerOptions options)
        {
            // convert NormalizedString to string for JSON output
            string stringValue = value;
            writer.WriteStringValue(stringValue);
        }
    }
}