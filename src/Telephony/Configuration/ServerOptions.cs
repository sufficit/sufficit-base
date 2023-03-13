using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Configuration
{
    public class ServerOptions
    {
        public string? Title { get; set; }
        public string Address { get; set; } = default!;
        public string? User { get; set; }
        public string? Password { get; set; }
        public uint Port { get; set; } = 80;

        public override bool Equals(object? other) =>
          other is ServerOptions p && 
            p.Title == Title && 
            p.Address == Address && 
            p.User == User && 
            p.Password == Password &&
            p.Port == Port;

        public override int GetHashCode() => (Title, Address, User, Password, Port).GetHashCode();
    }
}
