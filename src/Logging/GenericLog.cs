using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sufficit.Logging
{
    /// <summary>
    ///     Long term event registration, content of type T
    /// </summary>
    public class GenericLog<T> : LogBase
    {
#if NETSTANDARD2_0
        public virtual T Content { get; set; }
#else
        public virtual T? Content { get; set; }
#endif
    }
}
