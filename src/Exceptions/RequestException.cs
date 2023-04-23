using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exceptions
{
    /// <summary>
    /// User request exception
    /// </summary>
    public class RequestException : Exception
    {
        public RequestException() { }
        public RequestException(string message) : base(message) { }
    }
}
