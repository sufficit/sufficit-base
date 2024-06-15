using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification
{
    public class Subscription
    {
        public Guid ContextId { get; set; }
        public Guid EventId { get; set; }
        public string Key { get; set; } = string.Empty;
        public Guid ContactId { get; set; }

        /// <summary>
        ///     Last update time
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
