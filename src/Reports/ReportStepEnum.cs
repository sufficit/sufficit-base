namespace Sufficit.Reports
{
    public enum ReportStepEnum
    {
        /// <summary>
        /// Estado desconhecido
        /// </summary>
        UNKNOWN,

        /// <summary>
        /// Parametros básicos aceitos para iniciar (relatório instanciado)
        /// </summary>
        ACCEPTED = 10,

        /// <summary>
        /// Fase de aquisição de dados para realizar os calculos
        /// </summary>
        FETCHING = 20,

        CONSOLIDING = 30,
        FILTERING = 40,
        PROCESSING = 50,
        FORMATTING = 90,
        FINISHED = 100,
        ERROR
    }
}
