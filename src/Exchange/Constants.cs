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
            ///     Dedicated queue for outbound call dispatch work items.
            /// </summary>
            public const string QCall = "Q-CALL";

            /// <summary>
            ///     Dedicated queue for voicemail working items.
            /// </summary>
            /// <remarks>
            ///     This queue is used by the new VoiceMail FastAGI script and should be used for all new voicemail-related work items. The legacy mailbox worker (e.g. Q-Mail) should be reserved for processing existing voicemail items until they are fully migrated to the new system.
            /// </remarks>
            public const string QVoiceMail = "Q-VOICEMAIL";

            /// <summary>
            ///     Outbound E-Mails
            /// </summary>
            public const string QEmail = "Q-EMAIL";

            /// <summary>
            ///    Dedicated queue for Outbound WhatsApp messages.
            /// </summary>
            /// <remarks>
            ///     WhatsApp return messages are routed to a separate queue (Q-WHATSAPP-RETURN) to avoid processing delays caused by outbound message handling.
            /// </remarks>
            public const string QWhatsApp = "Q-WHATSAPP";

            /// <summary>
            ///    Dedicated queue for Outbound Telegram messages.
            /// </summary>
            /// <remarks>
            ///     Telegram return messages are routed to a separate queue (Q-TELEGRAM-RETURN) to avoid processing delays caused by outbound message handling.
            /// </remarks>
            public const string QTelegram = "Q-TELEGRAM";

            /// <summary>
            ///     Telegram returning messages
            /// </summary>
            public const string QTelegramReturn = "Q-TELEGRAM-RETURN";

            /// <summary>
            ///     Whatsapp returning messages
            /// </summary>
            public const string QWhatsappReturn = "Q-WHATSAPP-RETURN";

            /// <summary>
            ///     System => events without proper destination
            /// </summary>
            public const string QSystemEventOrphans = "SYS-EVENT-ORPHANS";

            /// <summary>
            ///     E-Mails from asterisk service
            /// </summary>
            public const string QAsteriskMailboxEML = "ASTERISK-MAILBOX-EML";

            /// <summary>
            ///    Dedicated queue for Outbound Webhook messages from any source (generic)
            /// </summary>
            public const string QWebHook = "Q-WEBHOOK";

            /// <summary>
            ///    Dedicated queue for Outbound SMS messages from any source (generic)
            /// </summary>
            public const string QSMS = "Q-SMS";

            /// <summary>
            ///    Dedicated queue for generic push messages from any source (generic)
            /// </summary>
            public const string QPush = "Q-PUSH";

            /// <summary>
            ///     Internal system messages
            /// </summary>
            public const string QInternal = "Q-INTERNAL";
        }
    }
}
