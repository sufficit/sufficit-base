namespace Sufficit.Resources.Fail2Ban
{
    /// <summary>
    /// Request used to remove one blocked IP from one specific jail on one server.
    /// </summary>
    public class Fail2BanUnbanRequest
    {
        /// <summary>
        /// Server title configured in remote SSH options.
        /// </summary>
        public string Server { get; set; } = default!;

        /// <summary>
        /// Jail name that currently contains the blocked IP.
        /// </summary>
        public string Jail { get; set; } = default!;

        /// <summary>
        /// IP address to release.
        /// </summary>
        public string IP { get; set; } = default!;
    }
}