using System.ComponentModel;

namespace Sufficit.Telefonia
{
    public enum TChamado
    {
        /// <summary>
        /// Música de Espera
        /// </summary>
        [Description("Música de Espera")]
        MusicaDeEspera = 0,

        /// <summary>
        /// Somente Toque
        /// </summary>
        SomenteToque = 1,

        /// <summary>
        /// Agente Tocando
        /// </summary>
        AgenteTocando = 2
    }
}
