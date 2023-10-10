using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Contacts
{
    /// <summary>
    ///     Contact search parameters
    /// </summary>
    public class ContactSearchParameters : AttributeWithKeysSearchParameters
    {
        /// <summary>Owner | Creator</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ContextId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint Limit { get; set; }
    }
}
