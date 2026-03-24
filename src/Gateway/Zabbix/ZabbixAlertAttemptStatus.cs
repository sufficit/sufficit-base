namespace Sufficit.Gateway.Zabbix
{
    /// <summary>
    /// Lifecycle states for each persisted dialing attempt of a Zabbix alert.
    /// Used by <see cref="ZabbixAlertAttempt"/> and mapped as text in the EF model.
    /// </summary>
    public enum ZabbixAlertAttemptStatus
    {
        /// <summary>
        /// The attempt row exists but dialing has not started yet.
        /// Useful for queued or pre-created escalation steps.
        /// </summary>
        Pending = 0,

        /// <summary>
        /// The dispatcher is actively trying this destination.
        /// Intended for live outbound execution updates.
        /// </summary>
        Running = 1,

        /// <summary>
        /// The attempt reached a successful terminal outcome.
        /// The exact success rule will depend on the upcoming telephony workflow.
        /// </summary>
        Completed = 2,

        /// <summary>
        /// The attempt terminated with a failure.
        /// The matching detail should be stored in <see cref="ZabbixAlertAttempt.Error"/>.
        /// </summary>
        Failed = 3,

        /// <summary>
        /// The attempt was intentionally stopped before completion.
        /// Intended for flap suppression, manual interruption or strategy changes.
        /// </summary>
        Canceled = 4,
    }
}