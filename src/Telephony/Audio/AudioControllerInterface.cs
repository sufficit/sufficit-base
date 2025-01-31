using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Telephony.Audio
{
    /// <summary>
    /// Methods to manipulate Audios
    /// </summary>
    public interface AudioControllerInterface
    {
        /// <summary>
        /// Find a single or default object properties
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<AudioPlaceHolder?> Find(AudioSearchParameters parameters, CancellationToken cancellationToken);
    }
}
