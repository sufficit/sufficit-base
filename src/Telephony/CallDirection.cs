using System.ComponentModel;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Classify based on call direction <br />
    ///     Matching source and complementing with the destination (optional) to know if it is internal call
    /// </summary>
    public enum CallDirection : short
    {
        [Description("Impossível determinar")]
        UNKNOWN,

        [Description("Chamada interna do sistema, entre ramais ou aplicações diversas")]
        INTERNAL,

        [Description("Chamada externa de entrada, iniciada por alguém de fora do sistema")]
        INCOMING,

        [Description("Chamada externa de saída, iniciada por alguém de dentro com destino fora do sistema")]
        OUTBOUND,

        [Description("Chamada encaminhada")]
        MIXED
    }
}
