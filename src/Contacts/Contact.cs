using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [JsonPropertyName("id")]
        [Key, Column("id", TypeName = "binary(16)")]
        public Guid ID { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        [JsonPropertyName("title")]
        [Column("title", TypeName = "varchar(150)")]
        public virtual string? Title { get; set; }

        [DataMember(Name = "update", IsRequired = false)]
        [JsonPropertyName("update")]
        [Column("update", TypeName = "datetime")]
        public virtual DateTime Update { get; set; }        
    }
}
