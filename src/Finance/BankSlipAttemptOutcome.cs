namespace Sufficit.Finance
{
    /// <summary>
    /// Represents the provider-independent outcome of an external attempt.
    /// </summary>
    public enum BankSlipAttemptOutcome : byte
    {
        Succeeded = 1,
        Failed = 2,
        Ambiguous = 3
    }
}
