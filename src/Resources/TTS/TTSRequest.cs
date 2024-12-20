using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.TTS
{
    public class TTSRequest
    {
        /// <summary>
        ///     Unique identification for this request, used for caching
        /// </summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid Id { get; set; }


        [JsonPropertyName("text")]
        public string Text { get; set; } = default!;

        /// <summary>
        ///     Available engines are "neutral" | "standard"
        /// </summary>
        [JsonPropertyName("engine")]
        public string? Engine { get; set; } = "neutral";

        /// <summary>
        ///     Available pt-BR voices are "Vitoria" | "Camila" | "Ricardo" | "Thiago"
        /// </summary>
        [JsonPropertyName("voice")]
        public string? Voice { get; set; }

        [JsonPropertyName("rate")]
        public string? Rate { get; set; }


        [JsonPropertyName("format")]
        public string? Format { get; set; }

        /// <inheritdoc cref="Sufficit.Audio.AudioFormat.Rate"/>
        [JsonPropertyName("samplerate")]
        public uint? SampleRate { get; set; }
    }
}
