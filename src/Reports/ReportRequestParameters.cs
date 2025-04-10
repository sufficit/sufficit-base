using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Reports
{
    public class ReportRequestParameters : ReportParameters, IReportRequestParameters
    {
        /// <inheritdoc cref="IReportRequestParameters.Id"/>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? Id { get; set; }

        /// <inheritdoc cref="IReportRequestParameters.Await"/>
        [JsonPropertyName("await")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Await { get; set; }

        /// <summary>
        ///     Report Model Id, if defined, will be used to search for a specific report model
        /// </summary>
        [JsonPropertyName("modelid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ModelId { get; set; }

        [JsonExtensionData]
        [JsonPropertyName("extra")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IDictionary<string, object>? Extra { get; set; }

        public override bool Equals(object? obj)
            => obj is ReportRequestParameters other
            && Id == other.Id
            && Await == other.Await
            && ModelId == other.ModelId
            && base.Equals(other);

        public override int GetHashCode()
            => (Id, Await, ModelId).GetHashCode() ^ base.GetHashCode();
    }
}
