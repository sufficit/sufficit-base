using Sufficit.Telephony.Asterisk;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// IVR | URA<br />
    /// Enchanced Interactive Voice Response
    /// </summary>
    [DataContract]
    public class IVROption : AsteriskMenuOption
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        [DataMember(Name = "ivrid", IsRequired = true, Order = 0)]
        [Column("ivrid")]
        public Guid IVRId { get; set; }
    }
}
