namespace Sufficit.Resources.Fail2Ban
{
    /// <summary>
    /// Result returned after a Fail2Ban unblock operation.
    /// </summary>
    public class Fail2BanUnbanResult
    {
        /// <summary>
        /// Indicates whether the operation completed without validation or execution errors.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Human-readable operation summary.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Target server title for single unblock operations.
        /// </summary>
        public string? Server { get; set; }

        /// <summary>
        /// Target jail name for single unblock operations.
        /// </summary>
        public string? Jail { get; set; }

        /// <summary>
        /// Target IP for single unblock operations.
        /// </summary>
        public string? IP { get; set; }

        /// <summary>
        /// Number of servers touched by the operation.
        /// </summary>
        public int ServersAffected { get; set; }

        /// <summary>
        /// Number of distinct jails touched by the operation.
        /// </summary>
        public int JailsAffected { get; set; }

        /// <summary>
        /// Number of unblock commands executed successfully.
        /// </summary>
        public int EntriesAffected { get; set; }
    }
}