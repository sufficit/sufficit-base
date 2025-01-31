using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.EFData
{
    public static class Constants
    {
        public static class MySql
        {
            /// <summary>
            ///     (DATA) Basic connection string title without database information
            /// </summary>
            /// <remarks>* full privileges</remarks>
            public const string Default = "MySQLDefault";

            /// <summary>
            ///     (LOG) Basic full connection string title for log data
            /// </summary>
            /// <remarks>* full privileges</remarks>
            public const string LDDefault = "MySQLLOGDefault";

            /// <summary>
            ///     (DATA) => (realtime) 
            /// </summary>
            /// <remarks>* read only</remarks>
            public const string RTRead = "MySQLRTRead";

            /// <summary>
            ///     (LOG)
            /// </summary>
            /// <remarks>* read only</remarks>
            public const string LDRead = "MySQLLDRead";

            /// <summary>
            ///     (LOG) Manage extra contents other than CDR, like Messages, Events and Charts
            /// </summary>
            /// <remarks>* full privileges, no cdr</remarks>
            public const string LDExtra = "MySQLLDExtra";

            /// <summary>
            ///     (LOG) Billing purposes
            /// </summary>
            /// <remarks>* billing update privileges</remarks>
            public const string Billing = "MySQLBilling";

            public static class Databases
            {
                /// <summary>
                ///     (DATABASE) intranet relative data, CRM | ERP
                /// </summary>
                public const string Intranet = "intranet";
            }
        }
    }
}
