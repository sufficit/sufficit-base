using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Reports
{
    /// <inheritdoc cref="IReportProgress"/>
    public class ReportProgress : IReportProgress
    {
        /// <inheritdoc cref="IReportProgress.Percentage"/>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("percentage")]      
        public uint Percentage { get; set; }

        /// <inheritdoc cref="IReportProgress.Status"/>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <inheritdoc cref="IReportProgress.Step"/>
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
        [JsonPropertyName("accept")]
        public DateTime Accept { get; set; } = DateTime.UtcNow;

        /// <summary>
        ///     Date and time for the last status update
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        ///     Exception that was thrown during process
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("exception")]
        public JsonException? Exception { get; set; }

        #region FACILITIES FOR IMPLICIT CONVERSIONS

        public static implicit operator uint(ReportProgress source)
            => source.Percentage;

        public static implicit operator string? (ReportProgress source)
            => source.Status;

        public static implicit operator ReportStepEnum (ReportProgress source)
            => source.Step;

        public static implicit operator JsonException? (ReportProgress source)
            => source.Exception;

        #endregion
    }
}
