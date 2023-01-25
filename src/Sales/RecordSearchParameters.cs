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

namespace Sufficit.Sales
{
    public class RecordSearchParameters : ILimit
    {
        public Guid? ContextId { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        [DataMember(Name = "limit", IsRequired = false, Order = 1)]
        [Column("limit")]
        [JsonPropertyName("limit")]
        [DefaultValue(0)]
        public uint? Limit { get; set; }

        /// <summary>Filter for start range of invoice record</summary>    
        public DateTimeRange? Start { get; set; }

        /// <summary>Filter for end range of invoice record (expire)</summary>    
        public DateTimeRange? Expiration { get; set; }

        public bool? Active { get; set; }
    }
}
