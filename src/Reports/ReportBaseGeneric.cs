using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Reports
{
    /// <summary>
    ///   Base class for reports with generic items and parameters
    /// </summary>
    /// <remarks>*Good for Sufficit.Client responses</remarks>
    public class ReportBaseGeneric<TItems> : ReportBase
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("parameters")]
        [JsonPropertyOrder(1)]
        public ReportParameters? Parameters { get; set; }

        /// <summary>
        ///     Individual report items, enumerable, list, anything
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("items")]
        [JsonPropertyOrder(4)]
        public virtual IEnumerable<TItems> Items { get; set; } = default!;
    }    
}
