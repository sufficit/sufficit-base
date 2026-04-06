namespace Sufficit.Resources.Fail2Ban
{
    /// <summary>
    /// Search filters for active Fail2Ban blocks.
    /// </summary>
    public class Fail2BanBlockedAddressSearchParameters
    {
        /// <summary>
        /// Optional server title filter.
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