using System;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Modelo mais básico de chamadas telefônicas
    /// </summary>
    public class CallRecord : ICallRecordBasic
    {
        public DateTime Start { get; set; }

        public string Protocol { get; set; } = default!;

        public string Dialed { get; set; } = default!;

        public string Direction { get; set; } = default!;

        public string Model { get; set; } = default!;

        public string Disposition { get; set; } = default!;

        public string Origin { get; set; } = default!;

        public string Destination { get; set; } = default!;

        public uint Duration { get; set; }

        public uint Billing { get; set; }

        public string DID { get; set; } = default!;
    }
}
