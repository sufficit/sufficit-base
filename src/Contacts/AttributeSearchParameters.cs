using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Contacts
{
    public class AttributeSearchParameters
    {
        [Required]
        public string Key { get; set; } = default!;

        [DataMember(Name = "value", IsRequired = false)]
        public string? Value { get; set; }

        public bool ExactMatch { get; set; }
    }
}
