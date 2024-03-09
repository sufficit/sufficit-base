using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange
{
    public interface IMessageModel
    {
        /// <summary>
        /// Unique Id of this Message Model
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Easy common name
        /// </summary>
        string Name { get; }
    }
}
