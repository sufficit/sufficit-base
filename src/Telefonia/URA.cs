using Sufficit.Telephony;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Telefonia
{
    public class URA : Destino, IDestination, IFriendly
    {
        public const string FREEPBXPREFIX = "ivr";
        public const string FRIENDLYNAME = "URA / IVR";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENT INTERFACE IDESTINATION

        Guid? IDestination.Id => this.ID;

        string IDestination.TypeName => this.GetType().Name;

        Guid? IDestination.ContextId => this.IDContexto;

        string IDestination.Asterisk => this.Asterisk;

        string? IDestination.Title => this.Titulo;

        string? IDestination.Description => null;

        #endregion
        #region IMPLEMENTACAO DESTINO

        public override string Categoria => FRIENDLYNAME;

        #endregion

        //public Guid IDContexto { get; set; }
        public Guid IDAudio { get; set; }

        /// <summary>
        /// Extensão virtual para facilitar a transferência de chamadas; <br />
        /// Permite que o usuário ligue ou transfira chamadas diretamente para esta URA; <br />
        /// Deve ser único em cada contexto; <br />
        /// </summary>
        public int VExten { get; set; }

        public IDictionary<string, Destino> Destinos { get; } 
            = new Dictionary<string, Destino>();

        public int FPBXid { get; set; }
        public int FPBXaudio { get; set; }

        #region IMPLEMENTAÇÃO DESTINO

        [JsonIgnore]
        public override Type Classe => this.GetType();        

        #endregion
    }
}
