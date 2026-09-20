namespace Sufficit.Sales
{
    /// <summary>
    /// Defines when a recurring contract is financially settled. This is
    /// independent from the catalog billing mode and from the contract GUID.
    /// </summary>
    public enum ContractSettlementModel : byte
    {
        /// <summary>
        /// Compatibility value for clients that do not send the property. The
        /// server resolves it to Postpaid for new contracts and preserves the
        /// stored value for existing contracts.
        /// </summary>
        Unspecified = 0,

        /// <summary>A closed period may produce a receivable after consumption.</summary>
        Postpaid = 1,

        /// <summary>Confirmed payment must release coverage or balance before use.</summary>
        Prepaid = 2
    }
}
