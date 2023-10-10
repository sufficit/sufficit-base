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
    public class ContactWithAttributes : Contact//, IContact, IEnumerable<Attribute>, IContactWithAttributes, IIdTitlePair
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

        /*
        public IEnumerator<Attribute> GetEnumerator()
            => Attributes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Attributes.GetEnumerator();
        */

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
                    att.Value = value;
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

        /// <summary>
        ///     Return the value of first found key
        /// </summary>
        public string? GetValue(string key, string? description = null)
        {
            var ordered = Attributes.Where(s => s.Key == key.Trim().ToLower()).OrderBy(s => s.Description);      
            
            Attribute? attribute = null;
            
            if (description != null)
                attribute = ordered.FirstOrDefault(s => s.Description == description);

            return attribute?.Value ?? ordered.FirstOrDefault()?.Value;
        }
    }
}
