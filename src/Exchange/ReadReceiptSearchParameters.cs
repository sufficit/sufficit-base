using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange
{
    public class ReadReceiptSearchParameters :  ILimit
    {
        public Guid Id { get; set; }

        public DateTime? Start { get; set; }

        public uint? Limit { get; set; }
    }
}
