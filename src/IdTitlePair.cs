using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit
{
    public class IdTitlePair : IIdTitlePair
    {
        /// <summary>
        ///     Unique identifier for this object
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        [Key, Column("id", TypeName = "binary(16)")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Object text title (Optional)
        /// </summary>
        [DataMember(Name = "title", IsRequired = false)]
        [JsonPropertyName("title")]
        [JsonPropertyOrder(1)]
        [Column("title", TypeName = "varchar(150)")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual string? Title { get; set; }
    }
}
