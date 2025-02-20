﻿using System;
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

        public RequestException(string? message) : base(message) { }

        public RequestException(Exception inner) : base(inner.Message, inner) { }

        public RequestException(string? message, Exception? inner) : base(message, inner) { }

        public virtual string Title { get; } = "User Request Exception";

        public virtual string? Description { get; set; } = "Something went wrong";
    }
}
