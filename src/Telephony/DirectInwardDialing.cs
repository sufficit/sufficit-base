using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Description 
        {
            get => string.IsNullOrWhiteSpace(_description) ? null : _description;
            set => _description = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }

        private string _description = string.Empty;


        /// <summary>
        /// Regex to filter source calls caller ids <br />
        /// Only permit calls where does NOT match the criterias
        /// </summary>
        [JsonPropertyName("filter")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Filter
        {
            get => string.IsNullOrWhiteSpace(_filter) ? null : _filter;
            set => _filter = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }

        private string _filter = string.Empty;

        /// <summary>
        /// Prepend caller id names
        /// </summary>
        /// <example>#COMERCIAL</example>
        [JsonPropertyName("tags")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Tags
        {
            get => string.IsNullOrWhiteSpace(_tags) ? null : _tags;
            set => _tags = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }

        private string _tags = string.Empty;

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
        public string tdestino { get; set; } = string.Empty;
        
        [JsonIgnore]
        public string dstclasse { get; set; } = string.Empty;

        [JsonIgnore]
        public string dstid { get; set; } = string.Empty;

        #endregion

        #region IMPLEMENTING INTERFACE DIRECT INWARD DIALING

        string IDirectInwardDialing.Dialing => Extension;

        #endregion

        #region IMPLEMENTING INTERFACE INDEXABLE

        Guid IIndex.Id => Id;
        string? IIdTitlePair.Title => Extension;
        Guid IContextId.ContextId => ContextId;
        string IIndexable.Description => Description ?? string.Empty;

        #endregion
    }
}
