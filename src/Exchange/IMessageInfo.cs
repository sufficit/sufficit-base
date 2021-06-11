using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange
{
    public interface IMessageInfo
    {
        Guid ID { get; }

        /// <summary>
        /// Client that holds the track info for this message
        /// </summary>
        Guid IDContext { get; }

        /// <summary>
        /// Reference for another system object
        /// </summary>
        Guid IDReference { get; }

        /// <summary>
        /// Predefined model for the body of this message
        /// </summary>
        Guid IDModel { get; }

        /// <summary>
        /// Destination
        /// </summary>
        string Recipient { get; }

        /// <summary>
        /// Date and time that this message was accepted by the system
        /// </summary>
        DateTime TimeStamp { get; }
    }
}
