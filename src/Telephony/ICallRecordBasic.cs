﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public interface ICallRecordBasic
    {
        DateTime Start { get; }

        string Protocol { get; }

        string Dialed { get; }

        string Direction { get; }

        string Model { get; }

        string Disposition { get; }

        string Origin { get; }

        string Destination { get; }

        int Duration { get; }

        int Billing { get; }

        string DID { get; }
    }
}
