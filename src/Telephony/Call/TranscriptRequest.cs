﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Call
{
    public class TranscriptRequest
    {
        [JsonPropertyName("linkedid")]
        public string LinkedId { get; set; } = default!;

        [JsonPropertyName("ggml")]
        public string GGML { get; set; } = "small";

        [JsonPropertyName("force")]
        public bool Force { get; set; } = false;
    }
}
