using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Contacts
{
    [DataContract(Name = "contact")]
    public class ContactWithAttributes : Contact, IContact
    {
        public IEnumerable<Attribute> Attributes { get; set; }
            = Array.Empty<Attribute>();
    }
}
