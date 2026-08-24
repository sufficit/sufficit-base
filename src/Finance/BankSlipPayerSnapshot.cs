namespace Sufficit.Finance
{
    /// <summary>
    /// Represents the immutable payer data supplied to a provider.
    /// </summary>
    public class BankSlipPayerSnapshot
    {
        /// <summary>
        /// Optional opaque customer identifier previously mapped by the selected
        /// provider. When supplied, the gateway must validate it and must not
        /// create another customer from the public checkout capability.
        /// </summary>
        public string? ProviderCustomerId { get; set; }
        public string Document { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? CorporateName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public BankSlipPayerAddress? Address { get; set; }
    }
}
