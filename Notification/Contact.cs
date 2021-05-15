using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification
{
    public class Contact
    {
        public Guid IDContact { get; set; }
        public Guid IDContext { get; set; }
        public int Priority { get; set; }
        public TChannel Channel { get; set; }
        public string Destination { get; set; }

        /// <summary>
        /// Informações extras
        /// </summary>
        public string Extra { get; set; }

        /// <summary>
        /// Motivo para bloqueio
        /// </summary>
        public string Cause { get; set; }
    }
}
