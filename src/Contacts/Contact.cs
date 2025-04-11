using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sufficit.Contacts
{
    [DataContract(Name = "contact")]
    public class Contact : IdTitlePair, IContact
    {
        [DataMember(Name = "update", IsRequired = false)]
        [JsonPropertyName("update")]
        [JsonPropertyOrder(2)]
        [Column("update", TypeName = "datetime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual DateTime Update { get; set; }
    }
}
