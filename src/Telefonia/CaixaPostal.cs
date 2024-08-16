using Sufficit.Telephony;
using Sufficit.Telephony.FreePBX;
using System;

namespace Sufficit.Telefonia
{
    public class CaixaPostal : Destino, IDestination, IFriendly
    {
        public const string FREEPBXPREFIX = FreePBXMailBox.FREEPBXPREFIX;
        public const string FRIENDLYNAME = FreePBXMailBox.FRIENDLYNAME + " (Old)";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENT INTERFACE IDESTINATION

        Guid? IDestination.Id => this.ID;

        string IDestination.TypeName => this.GetType().Name;

        Guid? IDestination.ContextId => this.IDContexto;

        string IDestination.Asterisk => this.Asterisk;

        string? IDestination.Title => this.Titulo;

        string? IDestination.Description => string.Empty;

        #endregion
        public string Contexto { get; set; } = "default";
        public bool Anexo { get; set; } = true;
        public bool Armazenar { get; set; } = false;
        public bool Saudacao { get; set; } = false;
        public bool Empacotar { get; set; } = false;

        public static string ToAmigavel() => FRIENDLYNAME;
    }
}
