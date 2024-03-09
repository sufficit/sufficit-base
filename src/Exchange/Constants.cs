using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange
{
    /// <summary>
    ///     Partial (Exchange) constants deep class
    /// </summary>
    public static partial class Constants
    {
        public const string EMAILREGEX = @"[a-z0-9][a-z0-9\.\-_]+[a-z0-9]@[-a-z0-9]*\.[\.?[a-z0-9]*";

        //[Obsolete("2024/02/27 use Sufficit.Exchange.RabbitMQ.QTelegramReturn instead")]
        //public const string QUEUETELEGRAMRETURN = "Q-TELEGRAM-RETURN";

        public static class RabbitMQ 
        {
            /// <summary>
            ///     Telegram returning messages
            /// </summary>
            public const string QTelegramReturn = "Q-TELEGRAM-RETURN";


            /// <summary>
            ///     System => events without proper destination
            /// </summary>
            public const string QSystemEventOrphans = "SYS-EVENT-ORPHANS";

            /// <summary>
            ///     E-Mails from asterisk service
            /// </summary>
            public const string QAsteriskMailboxEML = "ASTERISK-MAILBOX-EML";

            /// <summary>
            ///     Internal system messages
            /// </summary>
            public const string QInternal = "Q-INTERNAL";
        }
    }
}
