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
        public ChannelEnum Channel { get; set; }
        public string Destination { get; set; }
        public string Extra { get; set; }
    }
}
