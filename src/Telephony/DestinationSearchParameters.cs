using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sufficit.Telephony
{
    public class DestinationSearchParameters
    {
        /// <summary>
        /// ID of context to filter destinations
        /// </summary>
        [DataMember(Name = "contextid", IsRequired = true, Order = 0)]
        [Column("contextid")]
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Text to filter, null or empty for all
        /// </summary>
        [DataMember(Name = "filter", IsRequired = false, Order = 1)]
        [Column("filter")]
        [JsonPropertyName("filter")]
        public string? Filter { get; set; }

        /// <summary>
        /// Max number of results to take, 0 or null for all
        /// </summary>
        [DataMember(Name = "limit", IsRequired = false, Order = 1)]
        [Column("limit")]
        [JsonPropertyName("limit")]
        public uint? Limit { get; set; }
    }
}
