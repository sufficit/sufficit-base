using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification
{
    /// <summary>
    /// This class should be enlisted on notification events collection
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    public class NotificationEventCollectionAttribute : Attribute, IEnList
    {
        public bool EnList { get; set; } = true;
    }
}
