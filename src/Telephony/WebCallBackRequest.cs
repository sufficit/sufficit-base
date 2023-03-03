using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class WebCallBackRequest
    {
        /// <summary>
        /// Guid ID of Client or Telephony context
        /// </summary>
        public Guid ContextId { get; set; }

        [Obsolete]
        public Guid IDContext { get => ContextId; set => ContextId = value; }

        /// <summary>
        /// Destination phone
        /// </summary>
        [Required]
        public string Destination { get; set; } = default!;

        /// <summary>
        /// Use identified outbound calls
        /// </summary>
        public bool Identified { get; set; }

        /// <summary>
        /// Prepend a label on caller name to internal users
        /// </summary>
        public string? Label { get; set; }

        /// <summary>
        /// Apply a delay before calling
        /// </summary>
        public int Delay { get; set; }

        /// <summary>
        /// Call a internal asterisk extension
        /// </summary>        
        public string? Extension { get; set; }

        /// <summary>
        /// Await until call started, or return just after validate
        /// </summary>
        public bool Await { get; set; } = false;
    }
}
