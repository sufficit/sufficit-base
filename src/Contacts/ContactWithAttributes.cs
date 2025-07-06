using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Contacts
{
    [DataContract(Name = "contact")]
    public class ContactWithAttributes : Contact
    {
        [JsonPropertyName("attributes")]
        [JsonPropertyOrder(3)]
        public HashSet<Attribute> Attributes { get; set; }
            
        [JsonConstructor]
        public ContactWithAttributes()
        {
            Attributes = new HashSet<Attribute>();
        }

        public ContactWithAttributes(Guid id) : this()
        {
            this.Id = id;
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("title")]
        [JsonPropertyOrder(1)]
        public override string? Title
        {
            get => Attributes.FirstOrDefault(s => s.Key == Sufficit.Contacts.Attributes.Title)?.Value;
            set
            {
                if (value == null)
                {
                    Attributes.RemoveWhere(s => s.Key == Sufficit.Contacts.Attributes.Title);
                    return;
                }

                var att = Attributes.FirstOrDefault(s => s.Key == Sufficit.Contacts.Attributes.Title);
                if (att == null)
                {
                    att = new Attribute() { Key = Sufficit.Contacts.Attributes.Title };
                    Attributes.Add(att);
                }

                if (att.Value != value)
                {
                    base.Title = att.Value = value;
                    Update = DateTime.UtcNow;
                }
            }
        }

        [JsonPropertyOrder(2)]
        [JsonPropertyName("update")]
        public override DateTime Update 
        {
            get
            {
                var atts = Attributes.OfType<IContactAttribute>();
                if (atts.Any()) {
                    var updateatt = atts.Max(s => s.Update);
                    if (updateatt > base.Update)
                        return updateatt;
                }
                return base.Update;
            } 
            set => base.Update = value; 
        }
    }
}
