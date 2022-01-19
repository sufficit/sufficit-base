using Sufficit.EFData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Tronco usado para discagem externa
    /// </summary>
    public class DialOutTrunk
    {
        public Guid context { get; set; }

        public string title { get; set; } = string.Empty;

        public int channels { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime update { get; }

        /// <summary>
        /// Data/Hora de expiração do serviço desse tronco específico
        /// </summary>
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime expire { get; set; }
    }
}
