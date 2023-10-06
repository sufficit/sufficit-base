using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Contacts
{
    /// <summary>
    ///     Insecure parameters, without context information, lookup all attributes and contacts
    /// </summary>
    public class AttributeSearchParameters
    {
        /// <summary>Contact Id</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonPropertyName("contactId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual Guid? ContactId { get; set; }

        /// <summary>
        ///     Filter values for passed keys filter keys or default ones
        /// </summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TextFilter? Value { get; set; }

        /// <summary>
        ///     Filter values for passed keys filter keys or default ones
        /// </summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TextFilter? Description { get; set; }

        /// <summary>
        ///     Search for value or description using these attributes keys <br />
        ///     If null, all keys will be used
        /// </summary>
        [JsonPropertyName("keys")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public HashSet<string>? Keys { get; set; }
    }
}
