using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange.Configuration
{
    public class ExchangeOptions
    {
        public const string SECTIONNAME = "Sufficit:Exchange:RabbitMQ";

        public string HostName { get; set; } = "exchange.sufficit.com.br";
        public string UserName { get; set; } = "testing";
        public string Password { get; set; } = "testing";
    }
}
