namespace Sufficit.Sales
{
    /// <summary>
    ///     Type of financial adjustment applied to a billing period.
    /// </summary>
    public enum ContractAdjustmentType : byte
    {
        /// <summary>
        ///     Credit created by proration of a partial period.
        /// </summary>
        ProrationCredit = 0,

        /// <summary>
        ///     Credit created by an interruption that affects billing.
        /// </summary>
        InterruptionCredit = 1,

        /// <summary>
        ///     Manual credit applied by an operator.
        /// </summary>
        ManualCredit = 2,

        /// <summary>
        ///     Manual debit applied by an operator.
        /// </summary>
        ManualDebit = 3,
    }
}
