using Sufficit.Telephony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Sufficit.Telefonia
{
    public class DestinoPersonalizado : Destino, IDestination, IFriendly
    {
        public const string FREEPBXCONTEXT = "customdests";
        public const string FRIENDLYNAME = "Aplicativos";

        #region IMPLEMENT INTERFACE IDESTINATION

        Guid? IDestination.Id => this.ID;

        string IDestination.TypeName => this.GetType().Name;

        Guid? IDestination.ContextId => this.IDContexto;

        string IDestination.Asterisk => this.Asterisk;

        string? IDestination.Title => this.Titulo;

        string? IDestination.Description => null;

        #endregion
        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENTACAO DESTINO

        public override string Titulo => Descricao;
        public override string Categoria => FRIENDLYNAME;

        #endregion

        /// <summary>
        ///     Target with parameters (*)
        /// </summary>
        public string Objetivo { get; set; } = string.Empty;

        /// <summary>
        ///     Where GoTo after main task
        /// </summary>
        public Destino Destino { get; set; } = default!;

        public int FPBXid { get; set; }

        public bool FPBXRetorna { get { return !string.IsNullOrWhiteSpace(Destino); } }

        /// <summary>
        /// usado em /telefonia/freepbx/destinospersonalizados
        /// </summary>
        public string? FPBXValor { get; set; }

        #region IMPLEMENTAÇÃO DESTINO

        [JsonIgnore]
        public override Type Classe => this.GetType();

        #endregion
    }
}
