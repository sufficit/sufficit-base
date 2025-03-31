using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public struct CallBilling
    {
        public uint Seconds { get; set; }

        public decimal Cost { get; set; }

        public CallBilling (uint seconds) : this(seconds, 0) { }

        public CallBilling (uint seconds, decimal value) { Seconds = seconds; Cost = value; }

        public static implicit operator int (CallBilling source)
        {
            return (int)source.Seconds;
        }

        public static implicit operator uint (CallBilling source)
        {
            return source.Seconds;
        }

        public static implicit operator decimal (CallBilling source)
        {
            return source.Cost;
        }

        public static implicit operator CallBilling (uint source)
        {
            return new CallBilling(source);
        }

        public static implicit operator CallBilling (int source)
        {
            return new CallBilling((uint)source);
        }
    }
}
