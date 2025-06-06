﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Resources.Whisper
{
    public class WhisperStatistics
    {
        [JsonPropertyOrder(0)]
        [JsonPropertyName("threads")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint Threads { get; set; }

        [JsonPropertyOrder(1)]
        [JsonPropertyName("position")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Position { get; set; }

        [JsonPropertyOrder(2)]
        [JsonPropertyName("total")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint Total => End.HasValue ? (uint)(End.Value - Accepted).TotalMilliseconds : (uint)(DateTime.UtcNow - Accepted).TotalMilliseconds;

        [JsonPropertyOrder(2)]
        [JsonPropertyName("queue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint Queue
        { 
            get 
            { 
                if (!Enqueued.HasValue) return 0;
                if (!Start.HasValue) return (uint) (DateTime.Now - Enqueued.Value).TotalMilliseconds;
                return (uint) (Start.Value - Enqueued.Value).TotalMilliseconds;
            }
        }

        [JsonPropertyOrder(2)]
        [JsonPropertyName("process")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint Process 
        { 
            get 
            { 
                if (!Start.HasValue) return 0;
                if (!End.HasValue) return (uint)(DateTime.UtcNow - Start.Value).TotalMilliseconds;
                return (uint)(End.Value - Start.Value).TotalMilliseconds;
            }
        }

        [JsonPropertyOrder(3)]
        [JsonPropertyName("accepted")]
        public DateTimeOffset Accepted { get; set; } = DateTimeOffset.UtcNow;

        [JsonPropertyOrder(3)]
        [JsonPropertyName("enqueued")]
        public DateTimeOffset? Enqueued { get; set; }

        [JsonPropertyOrder(3)]
        [JsonPropertyName("start")]
        public DateTimeOffset? Start { get; set; }

        [JsonPropertyOrder(3)]
        [JsonPropertyName("end")]
        public DateTimeOffset? End { get; set; }
    }
}
