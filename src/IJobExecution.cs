using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit
{
    /// <summary>
    ///     Used to standarize a common execution for a generic job
    /// </summary>
    public interface IJobExecution
    {
        ValueTask Run(CancellationToken cancellationToken, params object?[] args);
    }
}
