using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class DestinationSearchParameters : ILimit
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
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Minimum of 3 caracters long to start searching")]
        [JsonPropertyName("filter")]
        public string? Filter { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        [DataMember(Name = "limit", IsRequired = false, Order = 1)]
        [Column("limit")]
        [JsonPropertyName("limit")]
        public uint? Limit { get; set; } = 5;
    }
}
