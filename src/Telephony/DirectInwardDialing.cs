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
    public class DirectInwardDialing : DirectInwardDialingProperties, IDirectInwardDialing, IDirectInwardDialingExtra, IIndexable
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Any notes that facilitate the identification on searchs
        /// </summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Description { get; set; }

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

        /// <summary>
        /// Timestamp for service expiration
        /// </summary>
        [DateTimeKind(DateTimeKind.Utc)]
        [JsonPropertyName("expire")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Expire { get; set; }

        /// <summary>
        /// Should record at this moment <br />
        /// true = force, false = avoid, null = dontcare
        /// </summary>
        [JsonPropertyName("record")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Record { get; set; }

        /// <summary>
        /// Not in use for now
        /// </summary>
        [JsonPropertyName("update")]        
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public DateTime Update { get; set; }


        #region NOT THREATED YET

        [Obsolete]
        [JsonIgnore]
        public string tdestino { get; set; } = default!;

        public string dstclasse { get; set; } = default!;
        public string dstid { get; set; } = default!;

        #endregion

        #region IMPLEMENTING INTERFACE DIRECT INWARD DIALING

        string IDirectInwardDialing.Dialing => Extension;

        #endregion

        #region IMPLEMENTING INTERFACE INDEXABLE

        Guid IIndex.Id => Id;
        string? IIdTitlePair.Title => Extension;
        Guid IIndexable.ContextId => ContextId;
        string IIndexable.Description => Description ?? string.Empty;

        #endregion
    }
}
