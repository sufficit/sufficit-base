using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class Audio
    {
        [DataMember(Name = "id", IsRequired = true, Order = 0)]
        [Column("id")]
        public Guid Id { get; set; }

        [DataMember(Name = "cliente", IsRequired = true, Order = 0)]
        [Column("cliente")]
        public Guid IdContext { get; set; }

        [DataMember(Name = "titulo", IsRequired = true, Order = 0)]
        [Column("titulo")]
        public string Title { get; set; }

        [DataMember(Name = "url", IsRequired = true, Order = 0)]
        [Column("url")]
        public string Url { get; set; }
    }
}
