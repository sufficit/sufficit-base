using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
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

        public new TState State { get => (TState)base.State!; set => base.State = value; }

        public new Func<TState, Exception?, string>? Formatter {
            get => (state, ex) => (state != null ? base.Formatter?.Invoke(state, ex) : string.Empty) ?? string.Empty;
            set => base.Formatter = (state, ex) => (state is TState tstate ? value?.Invoke(tstate, ex) : string.Empty) ?? string.Empty;
        }
    }
}