using System.Runtime.Serialization;

namespace Sufficit.Reports
{
    public enum ReportStepEnum
    {
        /// <summary>
        /// Estado desconhecido
        /// </summary>
        [EnumMember(Value = "unknown")]
        UNKNOWN,

        /// <summary>
        /// Parametros básicos aceitos para iniciar (relatório instanciado)
        /// </summary>
        [EnumMember(Value = "accepted")]
        ACCEPTED = 10,

        /// <summary>
        /// Fase de aquisição de dados para realizar os calculos
        /// </summary>
        [EnumMember(Value = "fetching")]
        FETCHING = 20,

        [EnumMember(Value = "consoliding")]
        CONSOLIDING = 30,

        [EnumMember(Value = "filtering")]
        FILTERING = 40,

        [EnumMember(Value = "processing")]
        PROCESSING = 50,

        [EnumMember(Value = "formatting")]
        FORMATTING = 90,

        [EnumMember(Value = "finished")]
        FINISHED = 100,

        [EnumMember(Value = "error")]
        ERROR
    }
}
