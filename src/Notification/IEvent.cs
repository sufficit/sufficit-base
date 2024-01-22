using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Notification
{
    public interface IEvent : IIdTitlePair
    {
        string GetKey();

        ValueTask<string> GetBody(string? extra = null, TChannel channel = default);
    }
}
