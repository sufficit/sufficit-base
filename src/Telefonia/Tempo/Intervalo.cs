using System;

namespace Sufficit.Telefonia.Tempo
{
    public class Intervalo : IntervaloBase
    {
        public Guid ID { get; set; }
        public Guid IDContexto { get; set; }
        public string Titulo { get; set; } = default!;

        public override bool Equals(object? obj)
            => obj is Intervalo other &&
                other.ID == ID &&
                other.IDContexto == IDContexto &&
                other.Titulo == Titulo &&
                base.Equals(other);

        public override int GetHashCode()
            => (ID, IDContexto, Titulo, base.GetHashCode()).GetHashCode();
    }
}
