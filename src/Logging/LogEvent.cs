using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sufficit.Logging
{
    public class LogEvent
    {
        public LogEvent(string nameSpace, LoggerScope? scope)
        {
            NameSpace = nameSpace;
            Scope = scope;

            ID = Guid.NewGuid();
        }

        #region PRIMARY PROPERTIES

        public DateTime EventTime { get; } = DateTime.UtcNow;
        public Guid ID { get; }
        public string NameSpace { get; }
        public LoggerScope? Scope { get; }

        #endregion

        #region DEFAULT

        public LogLevel LogLevel { get; set; }
        public EventId EventId { get; set; }
        public Exception? Exception { get; set; }
        public virtual Func<object, Exception?, string>? Formatter { get; set; }

        #endregion

        public virtual object? State { get; set; }

        /// <summary>
        /// Default use of Formatter
        /// </summary>
        public string Message => Formatter?.Invoke(State!, Exception) ?? string.Empty;
    }
}