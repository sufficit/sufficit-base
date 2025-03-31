using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Reports
{
    /// <summary>
    ///     Report status properties
    /// </summary>
    public class ReportStatus
    {
        /// <summary>
        ///     Process progress percentage 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("percentage")]
        public decimal Percentage { get; set; }

        /// <summary>
        ///     Process info text message
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        ///     Named process step, if exists
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("step")]
        public ReportStepEnum Step { get; set; }

        /// <summary>
        ///     Date and time for process start
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("start")]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime? Start { get; set; }

        /// <summary>
        ///     Date and time for process finish
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("end")]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime? End { get; set; }
                
        /// <summary>
        ///     Date and time that the request was received by system
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        ///     Date and time for the last status update
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("update")]
        public DateTime? Update { get; set; }
    }
}
