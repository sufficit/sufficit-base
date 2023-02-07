namespace Sufficit.Telephony
{
    public class AsteriskQueueStatistics
    {
        public string Title { get; set; } = default!;
        public int Duration { get; set; }
        public int BillSec { get; set; }
        public int FirstSequence { get; set; }
    }
}
