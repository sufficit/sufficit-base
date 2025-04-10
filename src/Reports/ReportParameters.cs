using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Reports 
{
    public class ReportParameters
    {
        /// <summary>
        ///     Context, Client, Customer Id
        /// </summary>
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }

        /// <summary>
        ///     Provider Id
        /// </summary>
        [JsonPropertyName("providerid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ProviderId { get; set; }

        /// <summary>
        ///     DateTime to start search interval
        /// </summary>
        [JsonPropertyName("start")]
        [DateTimeKind(DateTimeKind.Utc)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Start { get; set; }

        /// <summary>
        ///     DateTime to end search interval
        /// </summary>
        [JsonPropertyName("end")]
        [DateTimeKind(DateTimeKind.Utc)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? End { get; set; }

        /// <summary>
        /// Tempo de diferença entre UTC e o horário regional do usuário solicitante
        /// </summary>
        [JsonPropertyName("offset")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TimeSpan? OffSet { get; set; }


        public override bool Equals (object? obj)
            => obj is ReportParameters other
            && ContextId == other.ContextId
            && ProviderId == other.ProviderId
            && Start == other.Start
            && End == other.End
            && OffSet == other.OffSet;

        public override int GetHashCode()
            => (ContextId, ProviderId, Start, End, OffSet).GetHashCode();
    }
}
