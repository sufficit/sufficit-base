using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Reports
{
    public abstract class ReportBaseGeneric<TItems, TParameters> : ReportBase
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("parameters")]
        [JsonPropertyOrder(1)]
        public TParameters Parameters { get; set; } = default!;

        /// <summary>
        ///     Individual report items, enumerable, list, anything
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("items")]
        [JsonPropertyOrder(4)]
        public virtual IEnumerable<TItems> Items { get; set; } = default!;
    }    
}
