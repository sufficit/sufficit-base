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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Text { get; set; } = default!;

        /// <summary>
        ///     Available engines are "neural" | "standard"
        /// </summary>
        [JsonPropertyName("engine")]
        public string? Engine { get; set; } = "neural";

        /// <summary>
        ///     Available pt-BR voices are <see cref="Voices.VITORIA"/> | <see cref="Voices.CAMILA"/> | <see cref="Voices.RICARDO"/> | <see cref="Voices.THIAGO"/>
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
