using System.ComponentModel;
using System.Runtime.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Classify based on call direction <br />
    ///     Matching source and complementing with the destination (optional) to know if it is internal call
    /// </summary>
    public enum CallDirection : short
    {
        [Description("Impossível determinar")]
        [EnumMember(Value = "unknown")]
        UNKNOWN,

        [Description("Chamada interna do sistema, entre ramais ou aplicações diversas")]
        [EnumMember(Value = "internal")]
        INTERNAL,

        [Description("Chamada externa de entrada, iniciada por alguém de fora do sistema")]
        [EnumMember(Value = "incoming")]
        INCOMING,

        [Description("Chamada externa de saída, iniciada por alguém de dentro com destino fora do sistema")]
        [EnumMember(Value = "outbound")]
        OUTBOUND,

        [Description("Chamada encaminhada")]
        [EnumMember(Value = "mixed")]
        MIXED
    }
}
