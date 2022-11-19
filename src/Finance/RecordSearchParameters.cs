using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    public class RecordSearchParameters : ILimit
    {
        [Required]
        public Guid ContextId { get; set; } = default!;

        /// <inheritdoc cref="ILimit.Limit"/>
        [DataMember(Name = "limit", IsRequired = false, Order = 1)]
        [Column("limit")]
        [JsonPropertyName("limit")]
        [DefaultValue(10)]
        public uint? Limit { get; set; } = 10;

        /// <summary>Start period for search UTC</summary>
        /// <example><code>DateTime.Today</code></example>        
        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }
    }
}
