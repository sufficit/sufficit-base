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
        ///     Answer the call as soon as it enters, before the destination runs.
        ///     Null keeps the legacy behavior (answer on entry when <see cref="Billed"/>).
        ///     Carriers bill from the answer: false lets the destination (IVR, queue, agent) answer.
        /// </summary>
        [JsonPropertyName("answeronentry")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AnswerOnEntry { get; set; }

        /// <summary>Effective "answer on entry" decision, including the legacy default.</summary>
        [JsonIgnore]
        public bool AnswersOnEntry => AnswerOnEntry ?? Billed;

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
