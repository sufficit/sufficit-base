using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit
{
    /// <summary>
    /// Base class for search parameters, following Sufficit standardized search pattern.
    /// Includes optional sorting and paging parameters.
    /// </summary>
    public class SearchParameters
    {
        [JsonPropertyName("sorting")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public SortingParameters? Sorting { get; set; }

        [JsonPropertyName("paging")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public PagingParameters? Paging { get; set; }
    }
}
