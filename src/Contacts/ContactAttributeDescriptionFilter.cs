using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Contacts
{
    public class ContactAttributeDescriptionFilter
    {
        public Guid ContactId { get; set; }

        public TextFilter? Description { get; set; }
    }
}
