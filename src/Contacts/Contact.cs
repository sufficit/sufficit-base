using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Contacts
{
    [DataContract(Name = "contact")]
    public class Contact : IContact
    {
        /// <summary>
        /// Identificador exclusivo deste contato
        /// </summary>
        /// <remarks>Tipo de dados GUID uniqueidentifier</remarks>
        /// <value>Guid.NewGuid()</value>
        [DataMember(Name = "id", IsRequired = true)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        [Key, Column("id", TypeName = "binary(16)")]
        public Guid Id { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        [JsonPropertyName("title")]
        [JsonPropertyOrder(1)]
        [Column("title", TypeName = "varchar(150)")]
        public virtual string? Title { get; set; }

        [DataMember(Name = "update", IsRequired = false)]
        [JsonPropertyName("update")]
        [JsonPropertyOrder(2)]
        [Column("update", TypeName = "datetime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual DateTime Update { get; set; }
    }
}
