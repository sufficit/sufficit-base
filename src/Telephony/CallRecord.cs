using System;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Modelo mais básico de chamadas telefônicas
    /// </summary>
    public class CallRecord : ICallRecordBasic
    {
        public DateTime Start { get; set; }

        public string Protocol { get; set; } 

        public string Dialed { get; set; }

        public string Direction { get; set; }

        public string Model { get; set; }

        public string Disposition { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public int Duration { get; set; }

        public int Billing { get; set; }

        public string DID { get; set; }
    }
}
