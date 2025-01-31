﻿using Sufficit.Resources.TTS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Audio
{
    public class AudioMixRequestFromTTS : AudioMixRequestParameters
    {
        [JsonPropertyName("tts")]
        public TTSRequest TTSRequest { get; set; } = default!;

        [JsonPropertyName("contextid")]
        public Guid? ContextId { get; set; }

        [JsonPropertyName("userid")]
        public Guid? UserId { get; set; }
    }
}
