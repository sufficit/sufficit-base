using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Telephony
{
    public class ContextMapping
    {
        [DataMember(Name = "code", IsRequired = true, Order = 0)]
        [Column("code"), Required]
        public uint Code { get; set; }

        /// <summary>
        ///     Client ID
        /// </summary>
        [DataMember(Name = "contextid", IsRequired = true, Order = 0)]
        [Column("contextid"), Required]
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Last update time
        /// </summary>
        [DataMember(Name = "timestamp", IsRequired = true, Order = 1)]
        [Column("timestamp"), DatabaseGenerated(DatabaseGeneratedOption.Computed), Required]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }
    }
}
