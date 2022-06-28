using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Logging
{
    public class LogSearchParameters
    {
        /// <example><code>0</code></example>
        [DataMember(Name = "limit", IsRequired = false)]
        public int Limit { get; set; } = 10;
    }
}
