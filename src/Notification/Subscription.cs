using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification
{
    public class Subscription
    {
        public Guid IDContext { get; set; }
        public Guid IDEvent { get; set; }
        public string Key { get; set; }
        public Guid IDContact { get; set; }
    }
}
