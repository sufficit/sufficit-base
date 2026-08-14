namespace Sufficit.Gateway
{
    /// <summary>
    /// Carries a provider credential resolved from protected host
    /// configuration. Values must never be persisted in domain records.
    /// </summary>
    public class GatewayCredential
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? ApiKey { get; set; }

        /// <summary>
        /// Secret used only to authenticate inbound provider webhooks. This is
        /// deliberately distinct from the API key and must never be persisted
        /// in financial/domain records.
        /// </summary>
        public string? WebhookSecret { get; set; }
    }
}
