using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange
{
    public interface IReadReceipt
    {
        DateTime Timestamp { get; }

        string Description { get; }
    }
}
