using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    public interface IBankSlipController
    {
        Task<IEnumerable<BankSlipInfo>> Search (BankSlipSearchParameters parameters, CancellationToken cancellationToken);
    }
}
