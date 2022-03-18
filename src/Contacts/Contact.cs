using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

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
        [Key, Column("id", TypeName = "binary(16)")]
        public Guid ID { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        [Column("title", TypeName = "varchar(150)")]
        public virtual string Title { get; set; }

        [DataMember(Name = "update", IsRequired = false)]
        [Column("update", TypeName = "datetime")]
        public virtual DateTime Update { get; set; }        
    }
}
