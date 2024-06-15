using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Sufficit
{
    public class JsonStringTypeConverter : JsonConverter<Type>
    {
        public override Type? Read(
            ref Utf8JsonReader reader,
            Type _,
            JsonSerializerOptions __) => Type.GetType(reader.GetString()!);

        public override void Write(
            Utf8JsonWriter writer,
            Type value,
            JsonSerializerOptions _) => writer.WriteStringValue(value.ToString());
    }
}
