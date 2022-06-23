using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Sales
{
    public class ClientInformation : IClient, IIndex
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime Start { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime Activity { get; set; }
    }
}
