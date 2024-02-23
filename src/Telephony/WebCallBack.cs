using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public class WebCallBack
    {
        public Guid ContextId { get; set; }

        public string Asterisk { get; set; } = default!;
    }
}
