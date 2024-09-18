using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification
{
    public enum SubscribeMethod
    {
        ByKey = 0,
        ByContextId,
        ByKeyAndContextId,

        // system events with no subscribe method
        None = -1,
    }
}
