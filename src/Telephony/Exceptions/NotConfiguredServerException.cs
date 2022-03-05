using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Exceptions
{
    public class NotConfiguredServerException : Exception
    {
        public NotConfiguredServerException(string server) { Server = server; }

        public string Server { get; }

        public override string Message { get { return $"server: { Server }, not configured. see 'appsettings.json'."; } }
    }
}
