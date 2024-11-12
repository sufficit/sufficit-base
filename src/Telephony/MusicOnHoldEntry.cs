using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class MusicOnHoldEntry
    {
        [JsonPropertyName("classid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ClassId { get; set; } = default!;

        [JsonPropertyName("position")]
        public uint Position { get; set; }

        [JsonPropertyName("entry")]
        public string Entry { get; set; } = default!;
    }
}
