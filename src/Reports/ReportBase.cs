using Sufficit.Telephony.Asterisk;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Reports
{
    public abstract class ReportBase : IIndex
    {
        [JsonPropertyName("id")]
        [JsonPropertyOrder(0)]
        public Guid Id { get; set; }

        /// <inheritdoc cref="ReportStatus"/>
        [JsonPropertyName("status")]
        [JsonPropertyOrder(2)]
        public ReportStatus Status { get; set; }

        /// <inheritdoc cref="ReportDebug"/>
        [JsonPropertyName("debug")]
        [JsonPropertyOrder(3)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ReportDebug Debug { get; set; }

        public ReportBase() 
        {
            Status = new ReportStatus()
            {
                Timestamp = DateTime.UtcNow,
            };
            Debug = new ReportDebug();
        }
    }    
}
