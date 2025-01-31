using Sufficit.Resources.FFMpeg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Audio
{
    public class AudioMixProcess : IDisposable
    {
        [JsonIgnore]
        public MediaStream? VoiceStream { get; set; }

        [JsonPropertyName("voiceinfo")]
        public FFProbeResponse VoiceInfo { get; set; } = default!;

        [JsonIgnore]
        public MemoryStream? VoiceWavStream { get; set; }

        public FFProbeResponse VoiceWavInfo { get; set; } = default!;


        public VolumeResponse? VoiceVolume { get; set; }
        public VolumeResponse? VoiceVolumeAdusted { get; set; }
        public FFProbeResponse? VoiceWavDelayed { get; set; }
        public FFProbeResponse? VoiceWavPadded { get; set; }

        [JsonIgnore]
        public MemoryStream? MusicStream { get; set; }
        public FFProbeResponse MusicInfo { get; set; } = default!;


        public VolumeResponse? MusicVolume { get; set; }
        public VolumeResponse? MusicVolumeAdusted { get; set; }


        [JsonIgnore]
        public MemoryStream? MixedStream { get; set; }
        public FFProbeResponse MixedInfo { get; set; } = default!;


        public VolumeResponse? MixedVolume { get; set; }
        public VolumeResponse? MixedVolumeAdusted { get; set; }


        [JsonIgnore]
        public MemoryStream? FadeStream { get; set; }
        public FFProbeResponse FadedInfo { get; set; } = default!;

        /// <summary>
        ///     In seconds by ffprobe
        /// </summary>
        public double TotalDuration
        {
            get
            {
                if (FadedInfo != null) return (FadedInfo.Format?.Duration).GetValueOrDefault();
                if (MixedInfo != null) return (MixedInfo.Format?.Duration).GetValueOrDefault();
                if (VoiceWavPadded != null) return (VoiceWavPadded.Format?.Duration).GetValueOrDefault();
                if (VoiceWavDelayed != null) return (VoiceWavDelayed.Format?.Duration).GetValueOrDefault();
                if (VoiceWavInfo != null) return (VoiceWavInfo.Format?.Duration).GetValueOrDefault();

                return default;
            }
        }

        public void Dispose()
        {
            if (VoiceStream != null)
            {
                VoiceStream.Dispose();
                VoiceStream = null;
            }

            if (VoiceWavStream != null)
            {
                VoiceWavStream.Dispose();
                VoiceWavStream = null;
            }

            if (MusicStream != null)
            {
                MusicStream.Dispose();
                MusicStream = null;
            }

            if (MixedStream != null)
            {
                MixedStream.Dispose();
                MixedStream = null;
            }

            if (FadeStream != null)
            {
                FadeStream.Dispose();
                FadeStream = null;
            }
        }

        public MemoryStream GetResult()
        {
            if (FadeStream != null) return FadeStream;
            if (MixedStream != null) return MixedStream;
            if (MusicStream != null) return MusicStream;
            if (VoiceWavStream != null) return VoiceWavStream;

            throw new InvalidOperationException("no valid stream available");
        }
    }
}
