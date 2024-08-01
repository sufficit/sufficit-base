using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit
{
    /// <summary>
    ///     Executes an on demmand system cleanup
    /// </summary>
    public interface ICleanUp
    {
        /// <summary>
        ///     <inheritdoc cref="ICleanUp"/>
        /// </summary>
        /// <returns>count for affected items</returns>
        ValueTask<int> CleanUp(CancellationToken cancellationToken);
    }
}
