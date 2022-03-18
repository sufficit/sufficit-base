using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public interface IDirectInwardDialing
    {
        Guid ID { get; }

        string Dialing { get; }
    }
}
