using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Reports
{
    public interface IReportRequestParameters
    {
        /// <summary>
        ///     Report Id, if defined, will be used to search for a specific report, <br />
        ///     If null, empty or not cached, a new report will be generated
        /// </summary>
        public Guid? Id { get; }

        /// <summary>
        ///    Awaits for report generation complete, default(false)
        /// </summary>
        public bool? Await { get; }
    }
}
