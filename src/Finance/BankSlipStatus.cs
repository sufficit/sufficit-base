namespace Sufficit.Finance
{
    /// <summary>
    /// Represents the provider-independent lifecycle of a bank slip.
    /// </summary>
    public enum BankSlipStatus : byte
    {
        Requested = 1,
        Processing = 2,
        Ready = 3,
        Paid = 4,
        Canceled = 5,
        Failed = 6,
        ReconciliationPending = 7,
        CancellationRequested = 8,
        CancellationProcessing = 9
    }
}
