namespace Sufficit.Gateway.Zabbix
{
    /// <summary>
    /// Lifecycle states for a persisted Zabbix alert execution.
    /// Stored as text in EF and returned by the start/status API contracts.
    /// </summary>
    public enum ZabbixAlertExecutionStatus
    {
        /// <summary>
        /// The request was accepted at the API boundary, before full validation/persistence.
        /// Reserved for intermediate states if the controller flow becomes asynchronous.
        /// </summary>
        Accepted = 0,

        /// <summary>
        /// Integration, context and identifier checks succeeded and the execution row was persisted.
        /// This is the current terminal state reached by the synchronous start workflow.
        /// </summary>
        Validated = 1,

        /// <summary>
        /// Execution was intentionally suppressed by anti-flapping rules.
        /// Planned for the next operational phase when suppression is enforced on persisted history.
        /// </summary>
        SuppressedFlapping = 2,

        /// <summary>
        /// Real outbound processing is actively creating or running attempts.
        /// Intended for the future dispatcher implementation in the standard gateway layer.
        /// </summary>
        Running = 3,

        /// <summary>
        /// The execution finished successfully according to the final dialing policy.
        /// To be set when the dispatch stage reaches a successful terminal outcome.
        /// </summary>
        Completed = 4,

        /// <summary>
        /// The execution ended with an unrecoverable error.
        /// Expected to be paired with <see cref="ZabbixAlertExecution.Error"/>.
        /// </summary>
        Failed = 5,
    }
}