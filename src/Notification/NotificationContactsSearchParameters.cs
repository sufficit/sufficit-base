using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification
{
    public class NotificationContactsSearchParameters
    {
        /// <summary>
        ///     Get only valid or invalid contacts
        /// </summary>
        public bool? Valid { get; set; }

        /// <summary>
        ///     
        /// </summary>
        public Guid? EventId { get; set; }

        public string? Key { get; set; }
    }
}
