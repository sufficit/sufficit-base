using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Logging
{
    public class LogEvent<TState> : LogEvent
    {
        public LogEvent(string nameSpace, LoggerScope scope = null) : base(nameSpace, scope)
        {

        }

        public new TState State { get => (TState)base.State; set => base.State = value; }

        public new Func<TState, Exception, string> Formatter { 
            get => (state, ex) => base.Formatter(state, ex); 
            set => base.Formatter = (state, ex) => value((TState)state, ex); 
        }
    }

    public class LogEvent
    {
        public LogEvent(string nameSpace, LoggerScope scope = null)
        {
            NameSpace = nameSpace;
            Scope = scope;
            
            ID = Guid.NewGuid();
        }
        #region PRIMARY PROPERTIES

        public DateTime EventTime { get; } = DateTime.UtcNow;
        public Guid ID { get; }
        public string NameSpace { get; }
        public LoggerScope Scope { get; }

        #endregion

        #region DEFAULT

        public LogLevel LogLevel { get; set; }
        public EventId EventId { get; set; }
        public virtual object State { get; set; }
        public Exception Exception { get; set; }
        public virtual Func<object, Exception, string> Formatter { get; set; }

        #endregion

        public Guid IDMember { get; set; }
        public Guid IDContext { get; set; }


        /// <summary>
        /// Default use of Formatter
        /// </summary>
        public string Message => Formatter(State, Exception);
    }
}
