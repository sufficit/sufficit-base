using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.DIDs
{
    public class ExtraUpdateParameters : IDirectInwardDialingExtra
    {
        /// <summary>
        /// <inheritdoc cref="Sufficit.Telephony.DirectInwardDialing.Id"/>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc cref="Sufficit.Telephony.DirectInwardDialing.Description"/>
        /// </summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Description { get; set; }

        /// <summary>
        /// <inheritdoc cref="Sufficit.Telephony.DirectInwardDialing.Tags"/>
        /// </summary>
        [JsonPropertyName("tags")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Tags { get; set; }

        /// <summary>
        /// <inheritdoc cref="Sufficit.Telephony.DirectInwardDialing.Record"/>
        /// </summary>
        [JsonPropertyName("record")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Record { get; set; }
    }
}
