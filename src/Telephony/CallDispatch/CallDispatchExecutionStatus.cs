namespace Sufficit.Telephony.CallDispatch
{
    /// <summary>
    /// Lifecycle states for one persisted call dispatch execution.
    /// </summary>
    public enum CallDispatchExecutionStatus
    {
        /// <summary>
        /// The request was accepted and persisted but not yet consumed by the worker.
        /// </summary>
        Pending = 0,

        /// <summary>
        /// The dedicated worker is actively processing the execution.
        /// </summary>
        Running = 1,

        /// <summary>
        /// The dispatch finished without an unrecoverable error.
        /// </summary>
        Completed = 2,

        /// <summary>
        /// The dispatch ended with an unrecoverable error.
        /// </summary>
        Failed = 3,
    }
}