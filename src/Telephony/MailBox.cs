using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class MailBox : Destination, IFriendly
    {
        public const string ASTERISKCONTEXTDISABLED = "sufficit-mailbox-disabled";
        public const string FRIENDLYNAME = "Caixa Postal";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        public override string TypeName => typeof(MailBox).Name;

        public static MailBox Disabled { get; }
            = new MailBox() { Asterisk = $"{ASTERISKCONTEXTDISABLED},s,1", Title = "Desabilitado", Description = "Destino inválido" }; 
    }
}
