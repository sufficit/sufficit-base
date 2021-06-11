using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification.Configuration
{
    public class NotificationOptions
    {
        public const string SectionName = "Sufficit:Notification";

        public string ConnectionString { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            NotificationOptions other = obj as NotificationOptions;
            if (other != null)
            {
                string left = ConnectionString;
                string right = other.ConnectionString;
                return left == right;
            }
            else throw new ArgumentException($"Object is not a { GetType() }");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
