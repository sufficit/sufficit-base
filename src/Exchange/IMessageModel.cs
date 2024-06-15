using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange
{
    /// <summary>
    ///     Message model for internal events
    /// </summary>
    public interface IMessageModel
    {
        /// <summary>
        ///     Unique Id of this Message Model
        /// </summary>
        Guid Id { get; }

        /// <summary>
        ///     Easy common name
        /// </summary>
        string Name { get; }
    }
}
