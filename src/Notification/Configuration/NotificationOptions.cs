using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification.Configuration
{
    public class NotificationOptions
    {
        public const string SECTIONNAME = "Sufficit:Notification";

        public string ConnectionString { get; set; } = default!;

        public override bool Equals(object? obj)
            => obj is NotificationOptions p && p.ConnectionString == ConnectionString;

        public override int GetHashCode()
            => (ConnectionString).GetHashCode();
    }
}
