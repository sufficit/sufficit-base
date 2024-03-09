using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.FreePBX
{
    public class FreePBXCustomContext
    {
        public string context { get; set; } = default!;

        [MaxLength(100)]
        public string description { get; set; } = default!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? dialrules { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? faildestination { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? featurefaildestination { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? failpin { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool failpincdr { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? featurefailpin { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool featurefailpincdr { get; set; }
    }
}
