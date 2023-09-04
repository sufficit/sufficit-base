using System;

namespace Sufficit.Telefonia
{
    public class Anuncio : Destino, IDestino
    {
        #region IMPLEMENTACAO DESTINO

        public override string Titulo { get; set; } = default!;

        public override string Descricao { get; set; } = string.Empty;

        public override string Categoria => "Anúncio";

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

        public static string ToAmigavel() { return "Anúncio"; }

        public override Type Classe => this.GetType();

        #endregion
    }
}
