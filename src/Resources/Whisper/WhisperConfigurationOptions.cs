using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Resources.Whisper
{
    public class WhisperConfigurationOptions
    {
        public const string SECTIONNAME = nameof(Sufficit) + ":" + nameof(Resources) + ":" + nameof(Whisper);

        public uint MaxThreads { get; set; } = 6;

        public uint Simultaneous { get; set; } = 1;

        /// <summary>
        ///     keep factories in memory between process ?
        /// </summary>
        public bool Cache { get; set; } = true;
    }
}
