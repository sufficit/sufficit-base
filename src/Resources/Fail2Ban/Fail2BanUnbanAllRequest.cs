namespace Sufficit.Resources.Fail2Ban
{
    /// <summary>
    /// Request used to release all currently blocked IPs inside a filtered scope.
    /// </summary>
    public class Fail2BanUnbanAllRequest
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