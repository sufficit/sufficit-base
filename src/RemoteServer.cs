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
    public class RemoteServer : IRemoteServer
    {
        /// <inheritdoc cref="IRemoteServer.Title"/>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }

        /// <inheritdoc cref="IRemoteServer.Address"/>
        [JsonPropertyName("address")]
        public string Address { get; set; } = default!;

        /// <inheritdoc cref="IRemoteServer.Password"/>
        [JsonPropertyName("port")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint Port { get; set; }

        /// <inheritdoc cref="IRemoteServer.User"/>
        [JsonPropertyName("user")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? User { get; set; }

        /// <inheritdoc cref="IRemoteServer.Password"/>
        [JsonPropertyName("password")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Password { get; set; }

        public override bool Equals(object? obj)
            => obj is RemoteServer other && other.Title == Title && other.Address == Address && other.Port == Port && other.User == User && other.Password == Password;

        public override int GetHashCode()
            => (Title, Address, Port, User, Password).GetHashCode();
    }
}
