using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.SemanticUI
{
    [DataContract]
    public class SemanticUISearchItem
    {
        #region EXTRA

        [JsonPropertyName("id")]
        [DataMember(EmitDefaultValue = false)]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        [DataMember(EmitDefaultValue = false)]
        public string? Type { get; set; }

        [JsonPropertyName("asterisk")]
        [DataMember(EmitDefaultValue = false)]
        public string? Asterisk { get; set; }

        #endregion

        [JsonPropertyName("category")]
        public string Category { get; set; } = default!;

        [JsonPropertyName("title")]
        [DataMember(EmitDefaultValue = false)]
        public string? Title { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("image")]
        [DataMember(EmitDefaultValue = false)]
        public string? Image { get; set; }

        [JsonPropertyName("description")]
        [DataMember(EmitDefaultValue = false)]
        public string? Description { get; set; }

        [JsonPropertyName("price")]
        [DataMember(EmitDefaultValue = false)]
        public string? Price { get; set; }
    }
}
