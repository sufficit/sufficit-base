using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Asterisk
{
    public static class Constants
    {
        /// <summary>
        ///     Null or empty caller id or dialed numbers is represented by this constant.
        /// </summary>
        public const string MissingNumber = "unknown";

        /// <summary>
        ///    Default domain for VoIP calls, used in PJSIP configuration
        /// </summary>
        public const string DEFAULT_VOIP_DOMAIN = "voip.sufficit.com.br";

        /// <summary>
        ///     Asterisk SDP session name, public name for external systems
        /// </summary>
        public const string SDPSESSIONNAME = "Sufficit SDP";

        /// <summary>
        ///     Default asterisk language
        /// </summary>
        public const string LANGUAGE = "pt_br";

        /// <summary>
        ///     Default destination separator
        /// </summary>
        public const char DESTINATIONSEPARATOR = ',';

        public static class AsteriskVars
        {
            /// <summary>
            ///     Should id forward for outbound calls, trunk 'single' or user requested <br />
            ///     - stores <see cref="IdForwardPreference" />  
            /// </summary>
            public const string IdForward = "SUFFPUBLICIDFORWARD";

            /// <summary>
            ///     Use alternative route, common for identified calls <br />
            ///     - stores <see cref="bool" /> value  
            /// </summary>
            /// <remarks>used at [sufficit-dial-out]</remarks>
            public const string AlternativeDial = "SUFFALTERNATIVEDIAL";

            /// <summary>
            ///     Short representation for context|client id
            /// </summary>
            /// <remarks>*changing for CHANNEL(accountcode), marked for remove</remarks>
            public const string ContextId = "SUFFIDCLIENTE";

            /// <summary>
            ///     Discovered CallerId
            /// </summary>
            public const string CallerId = "SUFFCALLERID";


            public static class AGI
            {

            }
        }
    }
}
