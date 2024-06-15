using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification
{
    /// <summary>
    ///     Notifications subscriptions contacts search
    /// </summary>
    public class SubscribersSearchParameters
    {
        /// <summary>
        ///     Get only valid or invalid contacts
        /// </summary>
        public bool? Valid { get; set; }

        /// <summary>
        ///     Subscription Event Id
        /// </summary>
        public Guid? EventId { get; set; }

        /// <summary>
        ///     Subscription Keys 
        /// </summary>
        public IEnumerable<string>? Keys { get; set; }

        /// <summary>
        ///     Subscription (Context | Client | Customer), Id
        /// </summary>
        public Guid? ContextId { get; set; }
    }
}
