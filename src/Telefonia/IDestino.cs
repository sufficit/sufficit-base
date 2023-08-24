using System;

namespace Sufficit.Telefonia
{
    /// <summary>
    /// Objeto possui um ou mais destinos no plano de discagem
    /// </summary>
    public interface IDestino
    {
        Guid ID { get; set; }
        Destino Destino { get; set; }
    }
}
