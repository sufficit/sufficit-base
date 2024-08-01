using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.SemanticUI
{
    public class SemanticUISearchResponse
    {
        [JsonPropertyName("results")]
        public HashSet<SemanticUISearchCategory> Categories { get; set; }
            = new HashSet<SemanticUISearchCategory>();

        [JsonPropertyName("action")]
        [DataMember(EmitDefaultValue = false)]
        public SemanticUISearchAction? Action { get; set; }
    }
}
