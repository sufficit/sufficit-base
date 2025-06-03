using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.EndPoints
{
    public static partial class Constants
    {
        public const string DEFAULTDNS = "endpoints.sufficit.com.br";

        /// <summary>
        ///     Default url base for endpoints server
        /// </summary>
        public const string SERVERURL = "https://" + DEFAULTDNS;

        public static class Finance
        {
            public const string Area = "/" + nameof(Finance);
            public static class BankSlip
            {
                public const string Controller = "/" + nameof(BankSlip);
                public const string Download = Area + Controller + "/" + nameof(Download);
                public const string Preview = Area + Controller + "/" + nameof(Preview);
            }
        }

        public static class Telephony
        {
            public const string Area = "/" + nameof(Telephony);

            public static class Calls
            {
                public const string Controller = "/" + nameof(Calls);
                public const string Records = Area + Controller + "/" + nameof(Records);
            }

            public static class Recording
            {
                public const string Controller = "/" + nameof(Recording);
                public const string GetByLinkedId = Area + Controller + "/" + nameof(GetByLinkedId);
                public const string GetByUniqueId = Area + Controller + "/" + nameof(GetByUniqueId);
            }
        }
    }
}
