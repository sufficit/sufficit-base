using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange.Configuration
{
    public class ExchangeOptions
    {
        public const string SectionName = "Sufficit:Exchange:RabbitMQ";

        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            ExchangeOptions other = obj as ExchangeOptions;
            if (other != null)
            {
                string left = HostName + UserName + Password;
                string right = other.HostName + other.UserName + other.Password;
                return left == right;
            }
            else throw new ArgumentException($"Object is not a { GetType() }");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
