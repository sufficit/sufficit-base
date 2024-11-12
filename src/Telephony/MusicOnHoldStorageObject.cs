using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class MusicOnHoldStorageObject
    {
        public string Title { get; set; } = default!;


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ulong Length { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }
    }
}
