using System;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Indicates that filtering specifically for not answered calls is not implemented yet.
    /// </summary>
    public class UnAnsweredFilterNotImplementedException : NotImplementedException, IRequestException
    {
        /// <summary>
        /// Gets a short title suitable for API responses.
        /// </summary>
        public string Title => "Not answered filter not implemented";

        /// <summary>
        /// Gets the default exception message.
        /// </summary>
        public override string Message => "filtering by not answered still not implemented";

        /// <summary>
        /// Gets a short mitigation hint for the caller.
        /// </summary>
        public string Description => "try to enable or ignore this option for now";
    }
}
