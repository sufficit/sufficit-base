using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Telephony.CheckUp
{
    public interface ICheckUpMethods
    {
        IAsyncEnumerable<CheckUpStepInfo> CheckUpOutBoundRoutes(Guid ContextId, CancellationToken cancellationToken);        
    }
}
