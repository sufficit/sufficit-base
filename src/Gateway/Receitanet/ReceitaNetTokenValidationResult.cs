namespace Sufficit.Gateway.ReceitaNet
{
    /// <summary>
    /// Lightweight validation status for a single ReceitaNet token.
    /// </summary>
    public class ReceitaNetTokenValidationResult
    {
        /// <summary>
        /// Token that was validated.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Indicates whether the token was accepted by a lightweight compatibility probe.
        /// </summary>
        public bool Verified { get; set; }

        /// <summary>
        /// Human-readable validation message.
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}