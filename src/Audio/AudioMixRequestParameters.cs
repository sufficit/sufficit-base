using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Audio
{
    public class AudioMixRequestParameters : IIndex
    {
        /// <summary>
        ///     Unique identification for this request, used for caching
        /// </summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid Id { get; set; }

        /// <summary>
        ///     Amount of silence to insert on voice audio before mixing
        /// </summary>
        [JsonPropertyName("delay")]
        public TimeSpan? Delay {  get; set; }

        /// <summary>
        ///     Amount of silence to insert on voice audio after mixing
        /// </summary>
        [JsonPropertyName("padding")]
        public TimeSpan? Padding { get; set; }


        [JsonPropertyName("fadein")]
        public TimeSpan? FadeIn { get; set; }


        [JsonPropertyName("fadeout")]
        public TimeSpan? FadeOut { get; set; }

        [JsonPropertyName("music")]
        public Guid? Music { get; set; }

        /// <summary>
        ///     Music volume adjust
        /// </summary>
        [JsonPropertyName("musicvolume")]
        public float? MusicVolume { get; set; }

        /// <summary>
        ///     Voice volume adjust
        /// </summary>
        [JsonPropertyName("voicevolume")]
        public float? VoiceVolume { get; set; }

        /// <summary>
        ///     Mixed volume adjust
        /// </summary>
        [JsonPropertyName("mixedvolume")]
        public float? MixedVolume { get; set; }

        /// <summary>
        ///     Should apply a normalization for avoid peeks
        /// </summary>
        [JsonPropertyName("normalize")]
        public bool? Normalize { get; set; }

        /// <summary>
        ///     Should ignore recommendations
        /// </summary>
        [JsonPropertyName("forced")]
        public bool? Forced { get; set; }
    }
}
