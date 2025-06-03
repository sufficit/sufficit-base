using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public interface ICallRecordBasic
    {
        DateTime Start { get; }

        string Protocol { get; }

        /// <summary>
        ///     user dialed keys, if internal or outbound
        /// </summary>        
        string? Dialed { get; }

        string Direction { get; }

        string Model { get; }

        string Disposition { get; }

        string Origin { get; }

        string Destination { get; }

        uint Duration { get; }

        uint Billing { get; }

        string? DID { get; }
    }
}
