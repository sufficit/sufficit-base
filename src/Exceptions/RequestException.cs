using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit
{
    /// <summary>
    ///     User request exception
    /// </summary>
    public class RequestException : Exception, IRequestException
    {
        public RequestException() { }
        public RequestException(string message) : base(message) { }

        public virtual string Title { get; } = "User Request Exception";

        public virtual string? Description { get; set; } = "Something went wrong";
    }
}
