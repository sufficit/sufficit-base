using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.SemanticUI
{
    public class SemanticUISearchCategory
    {
        public const string DEFAULT = "Personalizado";

        [JsonPropertyName("name")]
        public string Name { get; set; } = DEFAULT;

        [JsonPropertyName("results")]
        public HashSet<SemanticUISearchItem> Items { get; set; } 
            = new HashSet<SemanticUISearchItem>();
    }
}
