using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit
{
    public class TimeoutCustomException : RequestException
    {
        public TimeoutCustomException(Exception? inner = null) : base(null, inner) { }

        public override string Title => "TimeOut";
        public override string Message => "The requested operation takes longer than needed, try again in a few seconds";
        public override string? Description => "Its not our fault, you should complain against the president";
    }
}
