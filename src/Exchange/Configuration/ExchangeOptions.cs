using System;

namespace Sufficit.Exchange.Configuration
{
    /// <summary>
    ///     RabbitMQ Options
    /// </summary>
    public class ExchangeOptions
    {
        public const string SECTIONNAME = "Sufficit:Exchange:RabbitMQ";

        /// <summary>
        ///     Should auto reconnect if fails
        /// </summary>
        public bool Persistent { get; set; } = true;

        public string HostName { get; set; } = "exchange.sufficit.com.br";
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;

        /// <summary>
        ///    Heartbeat interval for timeout detection
        /// </summary>
        public TimeSpan? Heartbeat { get; set; }

        public override bool Equals(object? obj)
            => obj is ExchangeOptions other && 
            other.Persistent == Persistent && 
            other.HostName == HostName && 
            other.UserName == UserName && 
            other.Password == Password && 
            other.Heartbeat == Heartbeat;

        public override int GetHashCode()
            => (Persistent, HostName, UserName, Password, Heartbeat).GetHashCode();
    }
}
