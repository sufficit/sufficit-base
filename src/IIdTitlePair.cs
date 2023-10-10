using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit
{
    /// <summary>
    /// Interface to items with Id and Title pair <br />
    /// Used on auto fill inputs
    /// </summary>
    public interface IIdTitlePair
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonPropertyName("id")]
        Guid Id { get; }

        /// <summary>
        /// Element text title (Optional)
        /// </summary>
        [JsonPropertyName("title")]
        string? Title { get; }
    }
}
