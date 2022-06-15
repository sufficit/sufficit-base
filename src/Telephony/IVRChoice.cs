using Sufficit.Telephony.Asterisk;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Interactive Voice Response user choice
    /// </summary>
    [DataContract]
    public class IVRChoice
    {
        /// <summary>
        /// IVR unique id
        /// </summary>
        [DataMember(Name = "ivrid", IsRequired = true, Order = 0)]
        [Column("ivrid")]
        public Guid IVRId { get; set; }

        /// <summary>
        /// Channel unique id
        /// </summary>
        [DataMember(Name = "uniqueid", IsRequired = true, Order = 1)]
        [Column("uniqueid"), StringLength(100)]
        public string UniqueId { get; set; }

        /// <summary>
        /// From external destination phone or internal extension
        /// </summary>
        [DataMember(Name = "source", IsRequired = true, Order = 2)]
        [Column("source"), StringLength(100)]
        public string Source { get; set; }

        /// <summary>
        /// User input
        /// </summary>
        [DataMember(Name = "digits", IsRequired = true, Order = 3)]
        [Column("digits"), StringLength(20)]
        public string Digits { get; set; }

        /// <summary>
        /// When happends
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }
}
