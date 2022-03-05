using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Exceptions
{
    public class DeniedDestinationException : Exception
    {
        public DeniedDestinationException(string destination) { Destination = destination; }

        public string Destination { get; }

        public override string Message { get { return $"destination denied or blacklisted: { Destination } !"; } }
    }
}
