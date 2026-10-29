using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Records how an unowned provider receipt was treated. Setting
    /// <see cref="BankSlipUnownedReceiptState.Open"/> reopens it.
    /// </summary>
    public sealed class BankSlipUnownedReceiptResolution
    {
        public Guid Id { get; set; }
        public BankSlipUnownedReceiptState State { get; set; }
        public string? Note { get; set; }
    }
}
