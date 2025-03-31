using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Reports
{
    public class ReportRequestParameters : ReportParametersNew
    {
        /// <summary>
        ///     Report Id, if defined, will be used to search for a specific report, <br />
        ///     If null, empty or not cached, a new report will be generated
        /// </summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? Id { get; set; }
    }
}
