using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Interface for checking if a destination is being used by a specific module
    /// </summary>
    public interface IDestinationInUse
    {
        /// <summary>
        /// Name of the module that implements this checker
        /// </summary>
        string ModuleName { get; }

        /// <summary>
        /// Priority for ordering results (lower values have higher priority)
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// Check if the destination is being used in this module
        /// </summary>
        /// <param name="destination">Destination to be checked</param>
        /// <returns>List of usage results found</returns>
        Task<IEnumerable<DestinationInUseResult>> InUseAsync(DestinationInUseCheck destination);
    }
}
