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
            public const string Controller = "/finance";
            public static class BankSlip
            {
                public const string Section = "/bankslip";

                public const string Download = Controller + Section + "/download";
                public const string Preview = Controller + Section + "/preview";
            }
        }
    }
}
