using Sufficit.Telephony.Asterisk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Methods to manipulate IVRs
    /// </summary>
    public interface IVRControllerInterface
    {
        /// <summary>
        /// Find a single or default ivr properties
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IVR?> Find(IVRSearchParameters parameters, CancellationToken cancellationToken);

        /// <summary>
        /// Clear and Update options of an IVR by Id
        /// </summary>
        /// <param name="ivrId"></param>
        /// <param name="options">If null, clear items</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Update(Guid ivrId, IEnumerable<AsteriskMenuOption> options, CancellationToken cancellationToken);
    }
}
