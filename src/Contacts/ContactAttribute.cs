using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Contacts
{
    [DataContract(Name = "attribute")]
    public class ContactAttribute : Attribute
    {
        [DataMember(Name = "idcontact", IsRequired = true)]
        [Key, Column("idcontact", TypeName = "binary(16)")]
        public Guid IDContact { get; set; }

        [DataMember(Name = "update", IsRequired = false)]
        [Column("update", TypeName = "datetime")]
        public virtual DateTime Update { get; set; }
    }
}
