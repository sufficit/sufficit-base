using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Contacts
{
    /// <summary>
    /// Represents search parameters for attributes, including a filter for specific attribute keys.
    /// </summary>
    /// <remarks>This class extends <see cref="AttributeSearchParameters"/> to allow filtering attributes by
    /// specific keys. If <see cref="Keys"/> is null, all attributes or default attributes will be retrieved.</remarks>
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
