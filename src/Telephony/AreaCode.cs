using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    [DataContract]
    public class AreaCode
    {
        /// <summary>
        /// Client Id
        /// </summary>
        [DataMember(Name = "contextid", IsRequired = true, Order = 0)]
        [Column("contextid")]
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Extension Id
        /// </summary>
        [DataMember(Name = "extensionid", IsRequired = true, Order = 1)]
        [Column("extensionid")]
        [JsonPropertyName("extensionid")]
        public Guid ExtensionId { get; set; }

        /// <summary>
        /// Region number, XX
        /// </summary>
        [DataMember(Name = "number", IsRequired = true, Order = 3)]
        [Column("number"), StringLength(2), DefaultValue("")]
        [JsonPropertyName("number")]
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// Last update time
        /// </summary>
        [DataMember(Name = "update", IsRequired = true, Order = 4)]
        [Column("update"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonIgnore]
        public DateTime Update { get; set; }
    }
}
