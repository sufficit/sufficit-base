using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Contacts
{
    [DataContract(Name = "attribute")]
    public class Attribute : IAttribute
    {
        [DataMember(Name = "key", IsRequired = true)]
        [Key, Column("key", TypeName = "char(30)")]
        public string Key { get; set; } = default!;

        [DataMember(Name = "value", IsRequired = false)]
        [Column("value", TypeName = "varchar(250)")]
        public string? Value { get; set; }

        [DataMember(Name = "description", IsRequired = true)]
        [Column("description", TypeName = "varchar(100)")]
        public string Description { get; set; } = default!;
    }
}
