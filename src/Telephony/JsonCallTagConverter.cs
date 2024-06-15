using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Sufficit.Telephony
{
    public class JsonCallTagConverter : JsonConverter<CallTag>
    {
        public override CallTag? Read(
            ref Utf8JsonReader reader,
            Type _,
            JsonSerializerOptions __) => (CallTag)reader.GetString()!;

        public override void Write(
            Utf8JsonWriter writer,
            CallTag value,
            JsonSerializerOptions _) => writer.WriteStringValue(value.ToString());
    }
}
