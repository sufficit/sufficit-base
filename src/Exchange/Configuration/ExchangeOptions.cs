namespace Sufficit.Exchange.Configuration
{
    public class ExchangeOptions
    {
        public const string SECTIONNAME = "Sufficit:Exchange:RabbitMQ";

        public string HostName { get; set; } = "exchange.sufficit.com.br";
        public string UserName { get; set; } = "testing";
        public string Password { get; set; } = "testing";

        public override bool Equals(object? obj)
            => obj is ExchangeOptions p && p.HostName == HostName && p.UserName == UserName && p.Password == Password;

        public override int GetHashCode()
            => (HostName, UserName, Password).GetHashCode();
    }
}
