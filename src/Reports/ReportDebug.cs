using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Reports
{
    /// <summary>
    ///     Report debug properties
    /// </summary>
    public class ReportDebug
    {
        /// <summary>
        ///     Fetching database elapsed time
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("fetchingtime")]
        public TimeSpan? FetchingTime { get; set; }

        /// <summary>
        ///     Processing elapsed time
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("processtime")]
        public TimeSpan? ProcessTime { get; set; }

        /// <summary>
        ///     Total retrieved records from database, before filtering
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("totalrecords")]
        public int TotalRecords { get; set; }

        /// <summary>
        ///     Total processed records
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("totalprocessed")]
        public int TotalProcessedRecords { get; set; }
    }
}
