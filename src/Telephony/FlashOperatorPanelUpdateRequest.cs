using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public class FlashOperatorPanelUpdateRequest
    {
        public Guid ContextId { get; set; }

        public bool Queues { get; set; }
            = true;

        public bool Force { get; set; }
            = true;

        public bool Ping { get; set; }
            = false;

        public uint TimeOutMs { get; set; }
            = 15000;
    }
}
