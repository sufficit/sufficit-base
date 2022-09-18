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
    public class RemoteServerOptions
    {
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; } = default!;

        [JsonPropertyName("port")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public uint Port { get; set; }

        [JsonPropertyName("user")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? User { get; set; }

        [JsonPropertyName("password")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Password { get; set; }

        public override bool Equals(object? obj)
            => obj is RemoteServerOptions other && other.Title == Title && other.Address == Address && other.Port == Port && other.User == User && other.Password == Password;

        public override int GetHashCode()
            => (Title, Address, Port, User, Password).GetHashCode();
    }
}
