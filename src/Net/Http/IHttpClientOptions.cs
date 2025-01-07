using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Net.Http
{
    public interface IHttpClientOptions
    {
        string BaseAddress { get; }

        string? UserAgent { get; }
        
        /// <summary>
        ///     Default TimeOut (seconds) for endpoints requests 
        /// </summary>
        uint? TimeOut { get; }
    }
}
