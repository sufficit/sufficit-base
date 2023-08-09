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
        public Guid? ContextId { get; set; }

        /// <summary>
        ///     Member that registered those records
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        ///     Filter by kind|type text
        /// </summary>
        public TextFilter? Kind { get; set; }

        /// <summary>
        ///     Filter by description text
        /// </summary>
        public TextFilter? Description { get; set; }

        /// <summary>
        ///     Filter by document information text
        /// </summary>
        public TextFilter? Document { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        [DataMember(Name = "limit", IsRequired = false, Order = 1)]
        [Column("limit")]
        [JsonPropertyName("limit")]
        [DefaultValue(10)]
        public uint? Limit { get; set; } = 10;

        public DateTimeMatch? Timestamp { get; set; }

        /// <summary>Start period for search UTC</summary>
        /// <example><code>DateTime.Today</code></example>        
        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        /// <summary>
        ///     Search only by active or inactive records, null = "dont care" | both
        /// </summary>
        public bool? Active { get; set; }
    }
}
