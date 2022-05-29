using System.ComponentModel;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Classificação quanto a direção das chamadas <br />
    /// Deduzido apartir da origem e usando o destino como complemento para saber se é interno
    /// </summary>
    public enum CallDirection
    {
        [Description("Impossível determinar")]
        UNKNOWN,

        [Description("Chamada interna do sistema, entre ramais ou aplicações diversas")]
        INTERNAL,

        [Description("Chamada externa de entrada, iniciada por alguém de fora do sistema")]
        INCOMING,

        [Description("Chamada externa de sáida, iniciada por alguém de dentro com destino fora do sistema")]
        OUTBOUND,

        [Description("Chamada encaminhada")]
        MIXED
    }
}
