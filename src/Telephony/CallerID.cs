using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Identificador de chamadas <br />
    /// Caller Identification
    /// </summary>
    [DataContract]
    public class CallerID
    {
        /// <summary>
        /// Client ID
        /// </summary>
        [DataMember(Name = "idcontext", IsRequired = true, Order = 0)]
        [Column("idcontext")]
        public Guid IDContext { get; set; }

        /// <summary>
        /// Extension ID
        /// </summary>
        [DataMember(Name = "idextension", IsRequired = true, Order = 1)]
        [Column("idextension")]
        public Guid IDExtension { get; set; }

        /// <summary>
        /// Provider ID
        /// </summary>
        [DataMember(Name = "idprovider", IsRequired = true, Order = 2)]
        [Column("idprovider")]
        public Guid IDProvider { get; set; }

        /// <summary>
        /// Number any format
        /// </summary>
        [DataMember(Name = "number", IsRequired = true, Order = 3)]
        [Column("number"), StringLength(25), DefaultValue("")]
        public string Number { get; set; }

        /// <summary>
        /// Name label
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, Order = 3)]
        [Column("name"), StringLength(70), DefaultValue("")]
        public string Name { get; set; }

        /// <summary>
        /// Last update time
        /// </summary>
        [DataMember(Name = "update", IsRequired = true, Order = 4)]
        [Column("update"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Update { get; set; }
    }
}
