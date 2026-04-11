namespace Sufficit.Resources.Fail2Ban
{
    /// <summary>
    /// Search filters for active Fail2Ban blocks.
    /// </summary>
    public class Fail2BanBlockedAddressSearchParameters
    {
        /// <summary>
        /// Optional server filter. Accepts a hostname, configured title, or address fragment.
        /// Case-insensitive; prefers an exact identity match before falling back to a contains search.
        /// When null or empty, all configured servers are queried.
        /// </summary>
        public string? Server { get; set; }

        /// <summary>
        /// Optional jail filter.
        /// </summary>
        public string? Jail { get; set; }

        /// <summary>
        /// Optional IP filter.
        /// </summary>
        public string? IP { get; set; }
    }
}