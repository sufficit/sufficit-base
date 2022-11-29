using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit
{
    /// <summary>
    /// Basic information options to use on instance of remote servers
    /// </summary>
    public interface IRemoteServer
    {
        /// <summary>
        /// Public name representation for this server
        /// </summary>
        string? Title { get; }

        /// <summary>
        /// Remote address to connect
        /// </summary>
        /// <example>Ip Address</example>
        string Address { get; }

        /// <summary>
        /// Remote public port
        /// </summary>
        uint Port { get; }

        /// <summary>
        /// Remote user authentication
        /// </summary>
        string? User { get; }

        /// <summary>
        /// Remote user password
        /// </summary>
        string? Password { get; }
    }
}
