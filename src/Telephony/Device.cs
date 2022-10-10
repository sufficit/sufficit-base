using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;

namespace Sufficit.Telephony
{
    public class Device
    {
        public string MACAddress { get; set; } = default!;
        public Guid? IDContext { get; set; }
        public Guid? IDExtension { get; set; }
        public string? Address { get; set; }

        [Column("update")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Update { get; set; }
    }
}
