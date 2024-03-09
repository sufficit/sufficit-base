using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    ///     Default financial record + Context & User infos
    /// </summary>
    public class ContextRecord : Record 
    {
        /// <summary>
        ///     CostCenter or Account
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        ///     User|Member Id Tracked
        /// </summary>
        public Guid UserId { get; set; }
    }
}
