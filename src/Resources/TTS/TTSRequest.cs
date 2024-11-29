using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.TTS
{
    public class TTSRequest
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = default!;

        [JsonPropertyName("ssml")]
        public string SSML { get; set; } = default!;

        /// <summary>
        ///     Available engines are "neutral" | "standard"
        /// </summary>
        [JsonPropertyName("engine")]
        public string? Engine { get; set; } = "neutral";

        /// <summary>
        ///     Available pt-BR voices are "Vitoria" | "Camila" | "Ricardo" | "Thiago"
        /// </summary>
        [JsonPropertyName("voice")]
        public string? Voice { get; set; } = "Thiago";

        [JsonPropertyName("rate")]
        public string? Rate { get; set; }


        [JsonPropertyName("format")]
        public string? Format { get; set; }
    }
}
