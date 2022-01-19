using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sufficit.Telephony.WebRTC
{
    /// <summary>
    /// Identificação e authenticação de uma seção WebRTC
    /// </summary>
    public class WebRTCSession
    {
        [Key]
        [Column("userid", TypeName = "binary(16)")]
        public Guid UserID { get; set; }

        [Column("key", TypeName = "binary(16)")]
        public Guid Key { get; set; }

        [Column("expiration")]
        public DateTime Expiration { get; set; }

        [Column("creation")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Creation { get; set; }

        [Column("update")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Update { get; set; }
    }
}
