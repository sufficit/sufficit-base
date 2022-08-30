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
        public TelephonyOptions()
        {
            Enabled = true;
            Servers = new ServersConfiguration();
            WebCallBack = new WebCallBackOptions();
        }

        /// <summary>
        /// Title of default configuration section (appsettings.json)
        /// </summary>
        public const string SECTIONNAME = "Sufficit:Telephony";

        public bool Enabled { get; set; }

        public ServersConfiguration Servers { get; }

        public WebCallBackOptions WebCallBack { get; }

        public override bool Equals(object? other) =>
          other is TelephonyOptions p && (p.Enabled, p.Servers, p.WebCallBack).Equals((Enabled, Servers, WebCallBack));

        public override int GetHashCode() => (Enabled, Servers, WebCallBack).GetHashCode();
    }
}
