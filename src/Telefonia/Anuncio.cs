﻿using Sufficit.Telephony;
using System;

namespace Sufficit.Telefonia
{
    public class Anuncio : Destino, IDestino, IDestination, IFriendly
    {
        public const string FREEPBXCONTEXT = "app-announcement";
        public const string FRIENDLYNAME = "Anúncio";

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
        #region IMPLEMENTACAO DESTINO

        public override string Titulo { get; set; } = default!;

        public override string Descricao { get; set; } = string.Empty;

        public override string Categoria => FRIENDLYNAME;

        #endregion

        public Destino Destino { get; set; } = default!;

        public Guid IDAudio { get; set; }

        public int FPBXid { get; set; }

        public int FPBXRecid { get; set; }

        public string FPBXDescription { get; set; } = string.Empty;

        public override bool Equals(object obj)
        {
            if (obj is Anuncio)
                if (FPBXid > 0)
                    if (FPBXid == ((Anuncio)obj).FPBXid) return true;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IMPLEMENTAÇÃO DESTINO

        public static string ToAmigavel() => FRIENDLYNAME;

        public override Type Classe => this.GetType();

        #endregion
    }
}
