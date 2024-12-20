using Sufficit.Resources.TTS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Audio
{
    public class AudioMixRequest
    {
        [JsonPropertyName("tts")]
        public TTSRequest TTS { get; set; } = default!;

        /// <summary>
        ///     Amount of silence to insert on voice audio before mixing
        /// </summary>
        public TimeSpan? Delay {  get; set; }

        /// <summary>
        ///     Amount of silence to insert on voice audio after mixing
        /// </summary>
        public TimeSpan? Padding { get; set; }

        public TimeSpan? FadeIn { get; set; }

        public TimeSpan? FadeOut { get; set; }

        public Guid? Music { get; set; }

        /// <summary>
        ///     Music volume adjust
        /// </summary>
        public float? MusicVolume { get; set; }

        /// <summary>
        ///     Voice volume adjust
        /// </summary>
        public float? VoiceVolume { get; set; }

        /// <summary>
        ///     Mixed volume adjust
        /// </summary>
        public float? MixedVolume { get; set; }

        /// <summary>
        ///     Should apply a normalization for avoid peeks
        /// </summary>
        public bool? Normalize { get; set; }
    }
}
