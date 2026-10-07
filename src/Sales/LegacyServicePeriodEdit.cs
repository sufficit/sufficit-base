using System;

namespace Sufficit.Sales
{
    /// <summary>Exact UTC dates for one current legacy service revision.</summary>
    public sealed class LegacyServicePeriodEdit
    {
        public Guid ServiceId { get; set; }
        public DateTime StartUtc { get; set; }
        public DateTime EndUtc { get; set; }
    }
}
