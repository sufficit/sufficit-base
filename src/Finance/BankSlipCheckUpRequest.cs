using System;

namespace Sufficit.Finance
{
    public class BankSlipCheckUpRequest
    {
        public Guid? ContextId { get; set; }

        public Guid? BankSlipId { get; set; }

        public TimeSpan? TimeSpan { get; set; }
    }
}
