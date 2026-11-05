namespace Sufficit.Sales
{
    /// <summary>
    /// Defines when a recurring contract is posted to the customer balance. This is
    /// independent from the catalog billing mode and from the contract GUID.
    /// </summary>
    public enum ContractSettlementModel : byte
    {
        /// <summary>
        /// Compatibility value for clients that do not send the property. The
        /// server resolves it to Prepaid for new contracts and preserves the
        /// stored value for existing contracts.
        /// </summary>
        Unspecified = 0,

        /// <summary>The financial debit is posted at the end of coverage; payment does not control service continuity.</summary>
        Postpaid = 1,

        /// <summary>The financial debit is posted at the start of coverage (default); a negative balance is permitted.</summary>
        Prepaid = 2
    }
}
