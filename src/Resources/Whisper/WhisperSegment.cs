using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.Whisper
{
    public class WhisperSegment
    {
        public string Text { get; set; } = default!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Language { get; set; } = default!;

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public float MinProbability { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public float MaxProbability { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public float Probability { get; set; }
    }
}
