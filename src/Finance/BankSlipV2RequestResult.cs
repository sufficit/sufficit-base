namespace Sufficit.Finance
{
    /// <summary>
    /// Represents an accepted issuance request and whether idempotency replayed an existing resource.
    /// </summary>
    public class BankSlipV2RequestResult
    {
        public BankSlipV2View BankSlip { get; set; } = default!;
        public bool Replayed { get; set; }
    }
}
