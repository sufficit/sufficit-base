using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    public interface ILegacyBankSlipController
    {
        Task<IEnumerable<LegacyBankSlipInfo>> Search (LegacyBankSlipSearchParameters parameters, CancellationToken cancellationToken);
    }
}
