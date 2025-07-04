using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Contacts
{
    /// <summary>
    /// Represents an attribute associated with a contact, providing metadata such as the contact's unique identifier
    /// and the last update timestamp.
    /// </summary>
    /// <remarks>This class is used to define attributes for contacts, including a required unique identifier
    /// and an optional timestamp for the last update. It is decorated with data contract attributes for serialization
    /// and database mapping attributes for persistence.</remarks>
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
