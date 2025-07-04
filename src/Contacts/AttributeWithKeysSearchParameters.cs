using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Contacts
{
    /// <summary>
    ///     <see cref="AttributeSearchParameters" /> + Keys
    /// </summary>
    public class AttributeWithKeysSearchParameters : AttributeSearchParameters
    {
        /// <summary>
        ///     After filter contact ids process, retrieves only these attribute keys
        ///     If null, all or default, attributes will be retrieved
        /// </summary>
        [JsonPropertyName("keys")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public HashSet<string>? Keys { get; set; }
    }
}
