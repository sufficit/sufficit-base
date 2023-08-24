using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit
{
    /// <summary>
    ///     User request exception
    /// </summary>
    public interface IRequestException
    {
        public string Title { get; }

        public string Message { get; }

        public string? Description { get; }
    }
}
