using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Basic information|properties about Direct Inward Dialing <br />
    ///     Only admins can change that
    /// </summary>
    public class DirectInwardDialingProperties
    {
        [Key]
        [JsonPropertyName("extension")]
        public string Extension { get; set; } = default!;

        [JsonPropertyName("providerid")]
        public Guid ProviderId { get; set; }

        [JsonPropertyName("billed")]
        public bool Billed { get; set; }

        /// <summary>
        ///     Answer the call on entry, before its destination runs (column <c>answer</c>).
        ///     Carriers bill from the answer, so false lets the destination (IVR, queue, agent)
        ///     answer when needed. Null keeps the legacy behavior: answer when <see cref="Billed"/>.
        /// </summary>
        [JsonPropertyName("answer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Answer { get; set; }

        /// <summary>Effective decision for <see cref="Answer"/>, including the legacy default.</summary>
        [JsonIgnore]
        public bool AnswerOnEntry => Answer ?? Billed;

        [JsonPropertyName("maxchannels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int MaxChannels { get; set; }

        /// <summary>
        /// Timestamp for the moment of this object was contracted, since billing start to count
        /// </summary>
        [JsonPropertyName("register")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Register { get; set; }
    }
}
