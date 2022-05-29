﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// IVR | URA<br />
    /// Enchanced Interactive Voice Response
    /// </summary>
    [DataContract]
    public class InteractiveVoiceResponse
    {
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
        public string Title { get; set; }

        /// <summary>
        /// Description used for information only
        /// </summary>
        [DataMember(Name = "description", IsRequired = false, Order = 3)]
        [Column("description"), StringLength(200), DefaultValue(null)]
        public string Description { get; set; }

        /// <summary>
        /// ID of announcement to be played at start
        /// </summary>
        [DataMember(Name = "idannouncement", IsRequired = false, Order = 1)]
        [Column("idannouncement")]
        public Guid IdAnnouncement { get; set; }

        /// <summary>
        /// ID of valediction to be played at end
        /// </summary>
        [DataMember(Name = "idvalediction", IsRequired = false, Order = 1)]
        [Column("idvalediction")]
        public Guid IdValediction { get; set; }

        /// <summary>
        /// Provides options for callers to direct dial an extension
        /// </summary>
        [DataMember(Name = "directdial", IsRequired = false, Order = 3)]
        [Column("directdial"), StringLength(1), DefaultValue(0)]
        public bool DirectDial { get; set; }

        /// <summary>
        /// Description used for information only
        /// </summary>
        [DataMember(Name = "extension", IsRequired = false, Order = 3)]
        [Column("extension"), StringLength(20), DefaultValue(null)]
        public string Extension { get; set; }

        /// <summary>
        /// Last update time
        /// </summary>
        [DataMember(Name = "update", IsRequired = true, Order = 4)]
        [Column("update"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Update { get; set; }
    }
}
