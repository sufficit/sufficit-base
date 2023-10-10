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
    ///     <see cref="AttributeSearchParameters" /> + Keys
    /// </summary>
    public class AttributeWithKeysSearchParameters : AttributeSearchParameters
    {
        /// <summary>
        ///     Returns only these attributes keys <br />
        ///     If null, all keys will be used
        /// </summary>
        [JsonPropertyName("keys")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public HashSet<string>? Keys { get; set; }
    }
}
