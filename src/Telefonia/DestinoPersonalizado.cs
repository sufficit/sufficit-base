using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Telefonia
{
    public class DestinoPersonalizado : Destino, IDestino
    {
        #region IMPLEMENTACAO DESTINO

        public override string Titulo => Descricao;
        public override string Categoria => "Aplicativos";

        #endregion

        //public Guid IDContexto { get; set; }
        public string Objetivo { get; set; } = string.Empty;

        public Destino Destino { get; set; } = default!;

        public int FPBXid { get; set; }

        public bool FPBXRetorna { get { return !string.IsNullOrWhiteSpace(Destino); } }

        /// <summary>
        /// usado em /telefonia/freepbx/destinospersonalizados
        /// </summary>
        public string? FPBXValor { get; set; }

        #region IMPLEMENTAÇÃO DESTINO

        public override Type Classe => this.GetType();

        #endregion
    }
}
