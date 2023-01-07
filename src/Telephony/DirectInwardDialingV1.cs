using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// DID = Linha de entrada no sistema de telefonia
    /// </summary>
    public class DirectInwardDialingV1 : IDirectInwardDialing, IIndexable
    {
        [Key]
        [JsonPropertyName("extension")]
        public string Extension { get; set; } = default!;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("providerid")]
        public Guid ProviderId { get; set; }

        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        [JsonPropertyName("billed")]
        public bool Billed { get; set; }

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Description { get; set; }

        /// <summary>
        /// Timestamp for the moment of this object was contracted, since billing start to count
        /// </summary>
        [JsonPropertyName("register")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Register { get; set; }

        [JsonPropertyName("maxchannels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int MaxChannels { get; set; }

        /// <summary>
        /// Regex to filter source calls caller ids <br />
        /// Only permit calls where does NOT match the criterias
        /// </summary>
        [JsonPropertyName("filter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Filter { get; set; }

        /// <summary>
        /// Prepend caller id names
        /// </summary>
        /// <example>#COMERCIAL</example>
        [JsonPropertyName("tags")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Tags { get; set; }

        [JsonPropertyName("asterisk")]
        public string Asterisk { get; set; } = default!;

        [JsonPropertyName("ownerid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? OwnerId { get; set; }

        [JsonPropertyName("update")]

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public DateTime Update { get; set; }

        #region NOT THREATED YET

        public string tdestino { get; set; } = default!;
        public string dstclasse { get; set; } = default!;
        public string dstid { get; set; } = default!;

        #endregion

        #region IMPLEMENTING INTERFACE DIRECT INWARD DIALING

        Guid IDirectInwardDialing.ID => Id;
        string IDirectInwardDialing.Dialing => Extension;

        #endregion

        #region IMPLEMENTING INTERFACE INDEXABLE

        Guid IIndex.Id => Id;
        Guid IIndexable.ContextId => ContextId;
        string IIndexable.Title => Extension;
        string IIndexable.Description => Description ?? string.Empty;

        #endregion
    }
}
