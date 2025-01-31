using System;
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
        ///     Filter by value
        /// </summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TextFilterWithKeys? Value { get; set; }

        /// <summary>
        ///     Filter by description 
        /// </summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TextFilterWithKeys? Description { get; set; }
    }
}
