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
        public const string SectionName = "Sufficit:Telephony";

        public bool Enabled { get; set; } = true;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            TelephonyOptions other = obj as TelephonyOptions;
            if (other != null)
            {
                string left = Enabled.ToString();
                string right = other.Enabled.ToString();
                return left == right;
            }
            else throw new ArgumentException($"Object is not a { GetType() }");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
