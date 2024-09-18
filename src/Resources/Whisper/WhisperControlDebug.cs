using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Resources.Whisper
{
    public class WhisperControlDebug
    {
        /// <summary>
        ///     Executions available
        /// </summary>
        public int Available { get; set; }

        public int Responses { get; set; }

        [JsonPropertyName("processes")]
        public WhisperProcessDebug Processes { get; }
            = new WhisperProcessDebug();

        [JsonPropertyName("threads")]
        public WhisperThreadDebug Threads { get; }
            = new WhisperThreadDebug();
        
    }

    public class WhisperProcessDebug
    {
        [JsonPropertyName("total")]
        public int Total => Items.Count;

        [JsonPropertyName("items")]
        public HashSet<WhisperProcessDebugItem> Items { get; } 
            = new HashSet<WhisperProcessDebugItem>();
    }

    public class WhisperThreadDebug
    {
        [JsonPropertyName("total")]
        public int Total => Items.Count;

        [JsonPropertyName("items")]
        public HashSet<WhisperThreadDebugItem> Items { get; }
            = new HashSet<WhisperThreadDebugItem>();
    }

    public class WhisperThreadDebugItem
    {
        [JsonPropertyName("alive")]
        public bool Alive { get; set; }

        [JsonPropertyName("threadstate")]
        public ThreadState? ThreadState { get; set; }
    }

    public class WhisperProcessDebugItem
    {
        public string Id { get; set; } = default!;

        [JsonPropertyName("whisperstatus")]
        public WhisperProcessStatus WhisperStatus { get; set; }

        [JsonPropertyName("taskstatus")]
        public TaskStatus? TaskStatus { get; set; }

    }
}
