using System;

namespace Sufficit.Telephony
{
    public class ExpirationUpdateParameters
    {
        public Guid Id { get; set; }

        public DateTime? Expiration { get; set; }
    }
}
