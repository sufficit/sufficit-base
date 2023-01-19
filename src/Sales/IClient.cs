using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Sales
{
    public interface IClient
    {
        Guid Id { get; }
        string? Title { get; } 
        string? Description { get; }
        DateTime Start { get; }
        DateTime Expiration { get; }
        DateTime Activity { get; }
    }
}
