using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using Sufficit.Json;

namespace Sufficit
{
    [AutoRegisterConverter]
    public class TextFilterConverter : JsonConverter<TextFilter?>
    {
        public override TextFilter? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            if (reader.TokenType == JsonTokenType.String)
            {
                // reads parsed data as string
                string value = reader.GetString()!;

                // default string to text filter converter
                return new TextFilter(value);
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                // avoids infinite loop
                var _options = new JsonSerializerOptions(options);
                _options.Converters.Remove(this);

                // default serializer
                return System.Text.Json.JsonSerializer.Deserialize<TextFilter?>(ref reader, _options);
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, TextFilter? data, JsonSerializerOptions options)
        {
            if (data == null)
            {
                writer.WriteNullValue();
                return;
            }

            // avoids infinite loop
            var _options = new JsonSerializerOptions(options);
            _options.Converters.Remove(this);

            // default guid to string representation
            System.Text.Json.JsonSerializer.Serialize(writer, data!, _options);           
        }
    }
}
