using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony.FreePBX
{
    public class FreePBXMailBox : Destination
    {
        public FreePBXMailBox(string asteriskExten)
        {
            Title = Extension = asteriskExten.Substring(3);

            Prefix = asteriskExten.Substring(0, 3);
            switch (Prefix)
            {
                case "vmb": Title += " - Ocupado"; break;
                case "vmu": Title += " - Indisponível"; break;
                case "vms": Title += " - Sem Mensagem"; break;
                case "vmi": Title += " - Apenas Instruções"; break;
            }
        }

        public override string TypeName => typeof(FreePBXMailBox).Name;

        /// <summary>
        /// Extension as Dial
        /// </summary>
        public string Extension { get; }

        /// <summary>
        /// MailBox Variant
        /// </summary>
        public string Prefix { get; }

        public override string Asterisk => $"ext-local,{Prefix}{Extension},1";
    }
}
