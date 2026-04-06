namespace Sufficit.Resources.Fail2Ban
{
    /// <summary>
    /// Represents a currently blocked IP entry reported by Fail2Ban.
    /// </summary>
    public class Fail2BanBlockedAddress
    {
        /// <summary>
        /// Server hostname derived from the configured SSH address whenever possible.
        /// </summary>
        public string Server { get; set; } = default!;

        /// <summary>
        /// Server environment resolved from remote server tags.
        /// </summary>
        public string Environment { get; set; } = default!;

        /// <summary>
        /// Jail name that currently contains the blocked IP.
        /// </summary>
        public string Jail { get; set; } = default!;

        /// <summary>
        /// Blocked IP address.
        /// </summary>
        public string IP { get; set; } = default!;

        /// <summary>
        /// Indicates whether the source server environment is production.
        /// </summary>
        public bool Production => string.Equals(Environment, "production", System.StringComparison.OrdinalIgnoreCase);
    }
}