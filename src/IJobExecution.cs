using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit
{
    /// <summary>
    /// Defines the execution boundary implemented by jobs hosted in the Sufficit
    /// Background runtime. Implementations are resolved from dependency injection
    /// and must honor cooperative cancellation.
    /// </summary>
    public interface IJobExecution
    {
        /// <summary>
        /// Executes the job using the optional persisted argument payload.
        /// </summary>
        /// <param name="cancellationToken">Signals runtime shutdown or operator cancellation.</param>
        /// <param name="args">Optional arguments supplied by the persisted schedule.</param>
        /// <returns>An optional result that the runtime will sanitize before logging.</returns>
        ValueTask<object?> Run(CancellationToken cancellationToken, params object?[]? args);
    }
}
