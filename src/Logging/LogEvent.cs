using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Logging
{
    public class LogEvent<TState> : LogEvent
    {
        public LogEvent(string nameSpace) : base(nameSpace, null)
        {

        }

        public LogEvent(string nameSpace, LoggerScope? scope) : base(nameSpace, scope)
        {

        }

        public new TState? State { get => (TState?)base.State; set => base.State = value; }

        public new Func<TState?, Exception?, string?> Formatter { 
            get => (state, ex) => base.Formatter?.Invoke(state, ex); 
            set => base.Formatter = (state, ex) => value?.Invoke((TState?)state, ex); 
        }
    }

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
        public virtual object? State { get; set; }
        public Exception? Exception { get; set; }
        public virtual Func<object?, Exception?, string?>? Formatter { get; set; }

        #endregion

        /// <summary>
        /// Default use of Formatter
        /// </summary>
        public string? Message => Formatter?.Invoke(State, Exception);
    }
}
