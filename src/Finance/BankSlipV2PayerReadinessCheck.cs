namespace Sufficit.Finance
{
    /// <summary>
    /// Describes one non-sensitive payer requirement evaluated before a bank
    /// slip issuance request is persisted.
    /// </summary>
    public class BankSlipV2PayerReadinessCheck
    {
        public string Code { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public bool Valid { get; set; }
        public string? Guidance { get; set; }
        public string ContactTab { get; set; } = string.Empty;
        public string? ContactField { get; set; }
    }
}
