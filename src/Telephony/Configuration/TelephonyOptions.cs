using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Configuration
{
    /// <summary>
    /// Opções padrão para o sistema de telefonia
    /// </summary>
    public class TelephonyOptions
    {
        /// <summary>
        /// Title of default configuration section (appsettings.json)
        /// </summary>
        public const string SECTIONNAME = "Sufficit:Telephony";

        public bool Enabled { get; set; } = true;
    }
}
