using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit
{
    /// <summary>
    ///     Interface used for get current user|member responsable for this context
    /// </summary>
    public interface IUserId
    {
        Guid? UserId { get; }
    }
}
