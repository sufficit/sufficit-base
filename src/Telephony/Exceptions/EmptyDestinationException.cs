﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Exceptions
{
    public class EmptyDestinationException : RequestException
    {
        public override string Message { get { return $"destination is empty."; } }
    }
}
