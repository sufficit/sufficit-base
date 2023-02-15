using System;
using System.ComponentModel.DataAnnotations;

namespace Sufficit.Telephony.DIDs
{
    public class ContextUpdateParameters
    {
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        /// <summary>
        /// Clearing extra informations
        /// </summary>
        public bool Clear { get; set; } = false;
    }
}
