namespace Sufficit.AI
{
    /// <summary>
    /// Status of an asynchronous Whisper processing request
    /// </summary>
    public enum WhisperProcessStatus
    {
        /// <summary>
        /// Request has been accepted and queued for processing
        /// </summary>
        Accepted = 0,

        /// <summary>
        /// Request is queued and waiting to be processed
        /// </summary>
        Queued = 1,

        /// <summary>
        /// Request is currently being processed
        /// </summary>
        Processing = 2,

        /// <summary>
        /// Request completed successfully
        /// </summary>
        Finished = 3,

        /// <summary>
        /// Request failed with an error
        /// </summary>
        Failed = 4
    }
}