using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Contacts
{
    public class ContextAttributeSearchParameters 
    {
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public Guid Id { get; set; }

        [JsonPropertyName("ownerid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? OwnerId { get; set; }

        [JsonPropertyName("groupid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? GroupId { get; set; }

        [JsonPropertyName("memberid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? MemberId { get; set; }
    }
}
