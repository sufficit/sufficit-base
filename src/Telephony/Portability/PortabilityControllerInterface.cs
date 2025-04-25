using Sufficit.EndPoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Telephony.Portability
{
    public interface PortabilityControllerInterface
    {        
        Task<PortabilityProcess?> ById (Guid id, CancellationToken cancellationToken);

        IAsyncEnumerable<PortabilityProcess> SearchAsAsyncEnumerable(PortabilitySearchParameters parameters, CancellationToken cancellationToken);

        Task<IEnumerable<PortabilityProcess>> Search(PortabilitySearchParameters parameters, CancellationToken cancellationToken);

        Task AddOrUpdate(PortabilityProcess item, CancellationToken cancellationToken);

        Task Remove(Guid id, CancellationToken cancellationToken);
    }
}
