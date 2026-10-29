namespace Sufficit.Finance
{
    /// <summary>
    /// Treatment state of a provider receipt that no Sufficit system owns.
    /// </summary>
    public enum BankSlipUnownedReceiptState : byte
    {
        /// <summary>Waiting for someone to identify the payer.</summary>
        Open = 1,

        /// <summary>Identified and handled (credited, linked or refunded).</summary>
        Resolved = 2,

        /// <summary>Not a customer payment (internal transfer, test).</summary>
        Dismissed = 3
    }
}
