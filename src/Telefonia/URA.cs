using System;
using System.Collections.Generic;

namespace Sufficit.Telefonia
{
    public class URA : Destino
    {
        #region IMPLEMENTACAO DESTINO

        public override string Categoria => "URA / IVR";

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

        public override Type Classe => this.GetType();

        #endregion
    }
}
