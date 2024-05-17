using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Sufficit.Telephony.Asterisk
{
    /// <summary>
    /// Menu options with asterisk destination
    /// </summary>
    [DataContract]
    public class AsteriskMenuOption : IAsteriskMenuOption
    {
        /// <summary>
        /// Digits the caller needs to dial to access said destination. Digits are limited to 3 digits.
        /// </summary>
        [DataMember(Name = "digits", IsRequired = true, Order = 0)]
        [Column("digits")]
        public string Digits { get; set; } = default!;

        /// <summary>
        /// Title used to show on results
        /// </summary>
        [DataMember(Name = "title", IsRequired = false, Order = 1)]
        [Column("title"), StringLength(50), DefaultValue(null)]
        public string? Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "dstasterisk", IsRequired = false, Order = 3)]
        [Column("dstasterisk"), StringLength(100), DefaultValue(null)]
        public string? DstAsterisk { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "dstid", IsRequired = false, Order = 3)]
        [Column("dstid"), StringLength(100)]
        public Guid? DstId { get; set; }

        private Type? DstType
        {
            get { return DstTypeName == null ? null : Type.GetType(DstTypeName); }
            set { DstTypeName = value == null ? null : value.AssemblyQualifiedName; }
        }

        [DataMember(Name = "dsttype", IsRequired = false, Order = 3)]
        [Column("dsttype"), StringLength(100), DefaultValue(null)]
        public string? DstTypeName { get; set; }
    }
}
