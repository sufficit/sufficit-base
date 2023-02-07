using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public interface IDirectInwardDialing
    {
        Guid Id { get; }

        string Dialing { get; }
    }
}
