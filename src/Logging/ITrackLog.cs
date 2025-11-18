using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Logging
{
    /// <summary>
    ///  Register json log into database
    /// </summary>
    public interface ITrackLog
    {
        /// <summary>
        ///  Register log into database
        /// </summary>
        Task Register<T>(GenericLog<T> log, CancellationToken cancellationToken);
    }
}