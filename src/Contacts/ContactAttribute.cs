using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Contacts
{
    [DataContract(Name = "attribute")]
    public class ContactAttribute : Attribute, IContactAttribute
    {
        [DataMember(Name = "contactid", IsRequired = true)]
        [Key, Column("contactid", TypeName = "binary(16)")]
        public virtual Guid ContactId { get; set; }

        [DataMember(Name = "update", IsRequired = false)]
        [Column("update", TypeName = "datetime")]
        public virtual DateTime Update { get; set; }
    }
}
