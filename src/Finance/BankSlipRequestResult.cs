namespace Sufficit.Finance
{
    /// <summary>
    /// Represents an accepted issuance request and whether idempotency replayed an existing resource.
    /// </summary>
    public class BankSlipRequestResult
    {
        public BankSlipView BankSlip { get; set; } = default!;
        public bool Replayed { get; set; }
    }
}
