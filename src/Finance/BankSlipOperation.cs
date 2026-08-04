namespace Sufficit.Finance
{
    /// <summary>
    /// Identifies an operation attempted against a bank slip provider.
    /// </summary>
    public enum BankSlipOperation : byte
    {
        Issue = 1,
        Query = 2,
        Cancel = 3,
        Reconcile = 4
    }
}
