using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Interface for how telephone calls can be filtered
    /// </summary>
    public interface ICallSearchParameters
    {
        /// <summary>
        /// Id (Guid) of the context to search for calls (client account or tenant)
        /// </summary>
        Guid? ContextId { get; }

        #region RANGE DATE TIME - MUST CHANGE THAT TO - Sufficit.DateTimeMatch?

        /// <summary>
        /// Start date/time of the search interval
        /// </summary>
        DateTime? Start { get; }

        /// <summary>
        /// (Optional) End date/time of the search interval <br />
        /// If not filled, the result will bring all records from the start date/time
        /// </summary>
        DateTime? End { get; }

        #endregion

        /// <summary>
        /// (Optional) Brings the results in the following time zone / region <br />
        /// The default is to bring everything in GMT
        /// </summary>
        RegionEnum? Region { get; }

        /// <summary>
        /// (Optional) Filters the search by only the selected DIDs, therefore, only incoming calls
        /// </summary>
        IEnumerable<string>? DIDs { get; }

        /// <summary>
        /// (Optional) Filters by only billed calls, which had or may generate costs <br />
        /// Default value (false)
        /// </summary>
        bool? Billed { get; }

        /// <summary>
        /// (Optional) Filters by only answered calls, which were marked as answered by the telephone exchange
        /// </summary>
        bool? Answered { get; }

        /// <summary>
        /// (Optional) Maximum number of call results to return after processing (approximate, not exact)
        /// </summary>
        int? Limit { get; }

        /// <summary>
        /// (Optional) Maximum data records to return and process
        /// </summary>
        uint? MaxRecords { get; }

        /// <summary>
        ///     (Optional) Text filter, for (linkedid)
        /// </summary>
        /// <remarks>*allow wildcard</remarks>
        string? Protocol { get; }

        /// <summary>
        ///     (Optional) Text filter, for (uniqueid) channel unique identifier, used by recordings
        /// </summary>
        /// <remarks>*only exact match</remarks>
        string? UniqueId { get; }

        /// <summary>
        ///     (Optional) Text filter, for (src or dst or cnum)
        /// </summary>
        string? Filter { get; }

        /// <summary>
        /// (Optional) Filters by specific tags associated with the calls
        /// </summary>
        IEnumerable<string>? Tags { get; }

        /// <summary>
        /// (Optional) Timeout for the search operation
        /// </summary>
        TimeSpan? TimeOut { get; }
    }
}
