using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// IVR | URA <br />
    /// Enchanced Interactive Voice Response
    /// </summary>
    [DataContract]
    public class IVR : IDestination, IFriendly
    {
        public const string ASTERISKCONTEXT = "sufficit-app-ivr";
        public const string FRIENDLYNAME = "IVR | MENU";
    
        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENT INTERFACE IDESTINATION

        Guid? IDestination.Id => Id;

        string IDestination.TypeName => typeof(IVR).Name;

        Guid? IDestination.ContextId => IdContext;

        string IDestination.Asterisk => $"{ASTERISKCONTEXT},{Id:N},1";

        string? IDestination.Title => Title;

        string? IDestination.Description => string.Empty;

        #endregion

        /// <summary>
        /// Unique ID
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 0)]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Client ID
        /// </summary>
        [DataMember(Name = "idcontext", IsRequired = true, Order = 0)]
        [Column("idcontext")]
        public Guid IdContext { get; set; }

        /// <summary>
        /// Title used to filter or locate this element
        /// </summary>
        [DataMember(Name = "title", IsRequired = true, Order = 3)]
        [Column("title"), StringLength(50), DefaultValue("")]
        public string Title { get; set; } = default!;

        /// <summary>
        /// Description used for information only
        /// </summary>
        [DataMember(Name = "description", IsRequired = false, Order = 3)]
        [Column("description"), StringLength(200), DefaultValue(null)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

        /// <summary>
        /// Can skip announcement with any digits
        /// </summary>
        [DataMember(Name = "canskipannouncement", IsRequired = false, Order = 3)]
        [Column("canskipannouncement"), DefaultValue(false)]
        public bool CanSkipAnnouncement { get; set; }

        /// <summary>
        /// ID of announcement to be played at start
        /// </summary>
        [DataMember(Name = "idannouncement", IsRequired = false, Order = 1)]
        [Column("idannouncement")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public Guid? IdAnnouncement { get; set; }

        /// <summary>
        /// ID of valediction to be played at end
        /// </summary>
        [DataMember(Name = "idvalediction", IsRequired = false, Order = 1)]
        [Column("idvalediction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public Guid? IdValediction { get; set; }

        /// <summary>
        /// Provides options for callers to direct dial an extension
        /// </summary>
        [DataMember(Name = "directdial", IsRequired = false, Order = 3)]
        [Column("directdial"), DefaultValue(false)]
        public bool DirectDial { get; set; }

        /// <summary>
        /// Description used for information only
        /// </summary>
        [DataMember(Name = "extension", IsRequired = false, Order = 3)]
        [Column("extension"), StringLength(20), DefaultValue(null)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Extension { get; set; }

        /// <summary>
        /// Last update time
        /// </summary>
        [DataMember(Name = "update", IsRequired = true, Order = 4)]
        [Column("update"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Update { get; set; }
    }
}
