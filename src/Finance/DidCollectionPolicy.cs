namespace Sufficit.Finance
{
    /// <summary>Versioned collection deadlines; evaluation never executes telephony commands.</summary>
    public sealed class DidCollectionPolicy
    {
        public string Version { get; set; } = "2026-10-01";
        public int GraceDays { get; set; } = 3;
        public int FinalReviewDays { get; set; } = 90;
        public int ManagerReminderDays { get; set; } = 7;
        public int QuarantineMonths { get; set; } = 6;
    }
}
