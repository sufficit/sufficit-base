using System;
using System.Text.Json.Serialization;

namespace Sufficit
{
    [Serializable]
    public class IdContextIdPair : IIndex, IContextId
    {
        /// <summary>
        ///     Unique identifier for this object
        /// </summary>
        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }


        /// <summary>
        ///     Context unique identifier
        /// </summary>
        [JsonPropertyOrder(0)]
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }
    }
}
