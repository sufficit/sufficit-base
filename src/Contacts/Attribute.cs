using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Contacts
{
    [DataContract(Name = "attribute")]
    public class Attribute : IAttribute
    {
        [JsonPropertyName("key")]
        [DataMember(Name = "key", IsRequired = true)]
        [Key, Column("key", TypeName = "char(30)")]
        public string Key { get; set; } = string.Empty;

        [DefaultValue("")]
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [DataMember(Name = "value", IsRequired = false)]
        [Column("value", TypeName = "varchar(250)")]
        public virtual string Value { get; set; } = string.Empty;

        [DefaultValue("")]
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [DataMember(Name = "description", IsRequired = true)]
        [Column("description", TypeName = "varchar(100)")]
        public virtual string Description { get; set; } = string.Empty;
    }
}
