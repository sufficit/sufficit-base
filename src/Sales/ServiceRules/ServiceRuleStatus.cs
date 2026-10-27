namespace Sufficit.Sales
{
    /// <summary>Lifecycle of a schedule. Only active schedules are read by workers.</summary>
    public enum ServiceRuleStatus : byte
    {
        Draft = 0,
        Active = 1,
        Retired = 2
    }
}
