using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Sufficit.Telephony.Asterisk
{
    public interface IAsteriskMenuOption
    {
        /// <summary>
        /// Digits the caller needs to dial to access said destination. Digits are limited to 3 digits.
        /// </summary>
        [DataMember(Name = "digits", IsRequired = true, Order = 0)]
        [Column("digits")]
        string Digits { get; }

        /// <summary>
        /// Title used to show on results
        /// </summary>
        [DataMember(Name = "title", IsRequired = false, Order = 1)]
        [Column("title"), StringLength(50), DefaultValue(null)]
        string? Title { get; }


        [DataMember(Name = "dstasterisk", IsRequired = false, Order = 3)]
        [Column("dstasterisk"), StringLength(100), DefaultValue(null)]
        string? DstAsterisk { get; }


        [DataMember(Name = "dstid", IsRequired = false, Order = 3)]
        [Column("dstid"), StringLength(100), DefaultValue(null)]
        Guid? DstId { get; }


        [DataMember(Name = "dsttype", IsRequired = false, Order = 3)]
        [Column("dsttype"), StringLength(100), DefaultValue(null)]
        public string? DstTypeName { get; }
    }
}
