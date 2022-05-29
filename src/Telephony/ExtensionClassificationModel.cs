using System.ComponentModel;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Classificação de chamadas com base no tipo de dispositivo
    /// </summary>
    public enum ExtensionClassificationModel
    {
        [Description("Formato não reconhecido")]
        UNKNOWN = 0,

        [Description("Telefones móveis nacionais")]
        MOBILE,

        [Description("Telefones fixo nacionais")]
        FIXED,

        [Description("Gratuidade nacional 0800")]
        TOLLFREE,

        [Description("Ramal / Extensão interna do sistema")]
        EXTENSION,

        [Description("Fila de chamada")]
        QUEUE,

        [Description("Chamadas não identificadas ou com chamador inválido/oculto")]
        ANONYMOUS,

        [Description("Chamadas internacionais")]
        INTERNATIONAL
    }
}
