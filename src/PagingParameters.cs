using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit
{
    public class PagingParameters
    {
        /// <summary>
        /// The requested index of the page to display.
        /// </summary>
        /// <remarks>
        /// The index of the first page is <c>0</c>.  
        /// </remarks>
        [JsonPropertyName("position")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Position { get; set; }

        /// <summary>
        /// The number of items requested.
        /// </summary>
        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint Size { get; set; }
    }
}
