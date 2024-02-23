using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Asterisk
{
    public class MusicOnHoldEntry
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("position")]
        public uint Position { get; set; }

        [JsonPropertyName("entry")]
        public string Entry { get; set; } = default!;
    }
}
