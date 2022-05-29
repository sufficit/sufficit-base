using System;
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
    public class InteractiveVoiceResponseOption
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        [DataMember(Name = "ivrid", IsRequired = true, Order = 0)]
        [Column("ivrid")]
        public Guid InteractiveVoiceResponseId { get; set; }

        /// <summary>
        /// Digits the caller needs to dial to access said destination. Digits are limited to 3 digits.
        /// </summary>
        [DataMember(Name = "digits", IsRequired = true, Order = 0)]
        [Column("digits")]
        public string Digits { get; set; }

        /// <summary>
        /// Title used to show on results
        /// </summary>
        [DataMember(Name = "title", IsRequired = false, Order = 1)]
        [Column("title"), StringLength(50), DefaultValue(null)]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "dstasterisk", IsRequired = false, Order = 3)]
        [Column("dstasterisk"), StringLength(100), DefaultValue(null)]
        public string DstAsterisk { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "dstid", IsRequired = false, Order = 3)]
        [Column("dstid"), StringLength(100), DefaultValue(null)]
        public Guid? DstId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "dsttype", IsRequired = false, Order = 3)]
        [Column("dsttype"), StringLength(100), DefaultValue(null)]
        public Type DstType { get; set; }
    }
}
