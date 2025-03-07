using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit
{
    public class GenericSearchResponse<T> 
    {
        [JsonPropertyName("total")]
        [JsonPropertyOrder(0)]
        public uint Total { get; set; }

        [JsonPropertyName("items")]
        [JsonPropertyOrder(1)]
        public IEnumerable<T> Items { get; set; } = Array.Empty<T>();
    }
}
