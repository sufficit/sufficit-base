using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Interface de como podem ser filtradas as chamadas telefonicas
    /// </summary>
    public interface ICallSearchParameters
    {
        /// <summary>
        /// ID do contexto a ser filtrado (cliente)
        /// </summary>
        Guid IDContext { get; }

        /// <summary>
        /// Data/Hora de início do intervalo de busca
        /// </summary>
        DateTime Start { get; }

        /// <summary>
        /// (Opcional) Data/Hora de término do intervalo de busca <br />
        /// Caso não seja preenchido, o resultado trará todos os registro apartir da data/hora de início
        /// </summary>
        DateTime? End { get; }

        /// <summary>
        /// (Opcional) Traz os resultados no seguinte fuso / região de horário <br />
        /// O padrão é trazer tudo em GMT
        /// </summary>
        RegionEnum? Region { get; }

        /// <summary>
        /// (Opcional) Filtra a pesquisa por apenas as DIDs selecionadas, portanto, somente chamadas de entrada
        /// </summary>
        string[]? DIDs { get; }

        /// <summary>
        /// (Opcional) Filtra por apenas chamadas tarifadas, que tiveram ou podem gerar custos <br />
        /// Valor padrão (false)
        /// </summary>
        bool Billed { get; }

        /// <summary>
        /// (Opcional) Filtra por apenas chamadas atendidas, que foram marcadas como atendidas pela central telefonica
        /// </summary>
        bool Answered { get; }

        /// <summary>
        /// (Opcional) Maximum call results, after processed (nearing, not exact)
        /// </summary>
        int Limit { get; }

        /// <summary>
        /// (Opcional) Maximum data records to return and process
        /// </summary>
        uint MaxRecords { get; }
    }
}
