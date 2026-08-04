namespace Sufficit.Finance
{
    /// <summary>
    /// Represents the immutable payer data supplied to a provider.
    /// </summary>
    public class BankSlipPayerSnapshot
    {
        public string Document { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? CorporateName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public BankSlipPayerAddress? Address { get; set; }
    }
}
