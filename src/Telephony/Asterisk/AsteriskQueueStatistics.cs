namespace Sufficit.Telephony
{
    public class AsteriskQueueStatistics
    {
        public string Title { get; set; } = default!;
        public uint Duration { get; set; }
        public uint BillSec { get; set; }
        public int FirstSequence { get; set; }
    }
}
