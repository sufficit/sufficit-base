using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sufficit.Logging
{
    public class LoggerScope : IDisposable
    {
        private readonly Stack<object> _scopes;

        public LoggerScope()
        {
            _scopes = new Stack<object>();
        }

        public LoggerScope(object[] states) : this()
        {
            foreach (object state in states)
                _scopes.Push(state);
        }

        public static implicit operator object[](LoggerScope scope)
        {
            return scope._scopes.ToArray();
        }

        public void Dispose()
        {
            _scopes.Pop();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            _scopes.Push(state); 
            return this;
        }

        /// <summary>
        /// (Snapshot) Creates a new instance with a copy of current element array
        /// </summary>
        /// <returns></returns>
        public LoggerScope GetScope()
        {
            if (_scopes.Any())            
                return new LoggerScope(this);
            
            return null;
        }

        public string[] GetStringArray()
        {
            return _scopes.ToArray().Select(s => s.ToString()).ToArray();
        }

        public override string ToString()
        {
            string[] vs = GetStringArray();
            if (vs.Length == 0) return string.Empty;

            return string.Join(", ", vs);
        }
    }
}
