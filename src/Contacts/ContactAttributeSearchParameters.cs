using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Contacts
{
    public class ContactAttributeSearchParameters : AttributeSearchParameters
    {
        [Required]
        public Guid ContactId { get; set; }
    }
}
