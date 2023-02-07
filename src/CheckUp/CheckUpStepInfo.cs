using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.CheckUp
{
    /// <summary>
    /// Information about a single step of an CheckUp task
    /// </summary>
    public class CheckUpStepInfo
    {
        /// <summary>
        /// When event occours
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Information about results
        /// </summary>
        public string Message { get; set; } = default!;

        /// <summary>
        /// Severity level of the message
        /// </summary>
        public LogLevel Level { get; set; }
    }
}
