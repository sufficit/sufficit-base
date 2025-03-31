using Sufficit.Telephony.Asterisk;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Reports
{
    public abstract class ReportBase<TItems, TParameters> : IIndex
    {
        [JsonPropertyName("id")]
        [JsonPropertyOrder(0)]
        public Guid Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("parameters")]
        [JsonPropertyOrder(1)]
        public TParameters Parameters { get; set; }

        /// <inheritdoc cref="ReportStatus"/>
        [JsonPropertyName("status")]
        [JsonPropertyOrder(2)]
        public ReportStatus Status { get; set; }

        /// <inheritdoc cref="ReportDebug"/>
        [JsonPropertyName("debug")]
        [JsonPropertyOrder(3)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ReportDebug Debug { get; set; }

        /// <summary>
        ///     Individual report items, enumerable, list, anything
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("items")]
        [JsonPropertyOrder(4)]
        public virtual IEnumerable<TItems> Items { get; set; }

        public ReportBase() 
        {
            Parameters = default!;
            Status = new ReportStatus()
            {
                Timestamp = DateTime.UtcNow,
            };
            Debug = new ReportDebug();
            Items = default!;
        }
    }    
}
