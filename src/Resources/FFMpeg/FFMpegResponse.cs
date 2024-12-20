using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.FFMpeg
{
    public class FFMpegResponse
    {
        [JsonPropertyName("exitcode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int ExitCode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Output { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Error { get; set; }


        public string WorkingDirectory { get; set; } = default!;

        public string FileName { get; set; } = default!;

        public string Arguments { get; set; } = default!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MemoryStream? Stream { get; set; }
    }
}
