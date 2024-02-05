using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Id forward preference for outbound calls
    /// </summary>
    public class IdForwardRequest : EndPointPropertyRequest
    {
        public IdForwardRequest() : base("idforward") { }
    }
}
