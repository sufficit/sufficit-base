using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit
{
    /// <summary>
    /// Interface used to limit the results to take on list or ienumerable retrieve
    /// </summary>
    public interface ILimit
    {
        /// <summary>
        /// Max number of results to take, 0 for all, null for default
        /// </summary>
        [DataMember(Name = "limit", IsRequired = false, Order = 1)]
        [Column("limit")]
        [JsonPropertyName("limit")]
        uint? Limit { get; }
    }
}
