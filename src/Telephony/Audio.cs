using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class Audio
    {
        [DataMember(Name = "id", IsRequired = true, Order = 0)]
        [Column("id"), JsonPropertyName("id")]
        public Guid Id { get; set; }

        [DataMember(Name = "cliente", IsRequired = true, Order = 0)]
        [Column("cliente"), JsonPropertyName("contextId")]
        public Guid ContextId { get; set; }

        [DataMember(Name = "titulo", IsRequired = true, Order = 0)]
        [Column("titulo"), StringLength(50), JsonPropertyName("title")]
        public string Title { get; set; } = default!;

        [DataMember(Name = "url", IsRequired = true, Order = 0)]
        [Column("url"), JsonPropertyName("url")]
        public Guid Url { get; set; }
    }
}
