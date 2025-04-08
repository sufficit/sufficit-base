using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Reports
{
    public abstract class ReportBase : IReport
    {
        /// <summary>
        ///     Unique identifier of this object
        /// </summary>
        [JsonPropertyName("id")]
        [JsonPropertyOrder(0)]
        public Guid Id { get; set; }

        /// <summary>
        ///     Unique identifier of the model used to generate this report
        /// </summary>
        [JsonPropertyName("modelid")]
        [JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual Guid ModelId { get; set; }

        /// <inheritdoc cref="ReportProgress"/>
        [JsonPropertyName("progress")]
        [JsonPropertyOrder(2)]
        public virtual ReportProgress Progress { get; set; } = new ReportProgress();

        /// <inheritdoc cref="ReportDebug"/>
        [JsonPropertyName("debug")]
        [JsonPropertyOrder(3)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ReportDebug Debug { get; set; } = new ReportDebug();
    }    
}
