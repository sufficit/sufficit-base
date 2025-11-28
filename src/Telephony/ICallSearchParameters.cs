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
        Guid? ContextId { get; }

        #region RANGE DATE TIME - MUST CHANGE THAT TO - Sufficit.DateTimeMatch?

        /// <summary>
        /// Data/Hora de início do intervalo de busca
        /// </summary>
        DateTime? Start { get; }

        /// <summary>
        /// (Opcional) Data/Hora de término do intervalo de busca <br />
        /// Caso não seja preenchido, o resultado trará todos os registro apartir da data/hora de início
        /// </summary>
        DateTime? End { get; }

        #endregion

        /// <summary>
        /// (Opcional) Traz os resultados no seguinte fuso / região de horário <br />
        /// O padrão é trazer tudo em GMT
        /// </summary>
        RegionEnum? Region { get; }

        /// <summary>
        /// (Opcional) Filtra a pesquisa por apenas as DIDs selecionadas, portanto, somente chamadas de entrada
        /// </summary>
        IEnumerable<string>? DIDs { get; }

        /// <summary>
        /// (Opcional) Filtra por apenas chamadas tarifadas, que tiveram ou podem gerar custos <br />
        /// Valor padrão (false)
        /// </summary>
        bool? Billed { get; }

        /// <summary>
        /// (Opcional) Filtra por apenas chamadas atendidas, que foram marcadas como atendidas pela central telefonica
        /// </summary>
        bool? Answered { get; }

        /// <summary>
        /// (Opcional) Maximum call results, after processed (nearing, not exact)
        /// </summary>
        int? Limit { get; }

        /// <summary>
        /// (Opcional) Maximum data records to return and process
        /// </summary>
        uint? MaxRecords { get; }

        /// <summary>
        ///     (Optional) Text filter, for (linkedid)
        /// </summary>
        /// <remarks>*allow wildcard</remarks>
        string? Protocol { get; }

        /// <summary>
        ///     (Optional) Text filter, for (uniqueid) channel unique identifier, used by recordings
        /// </summary>
        /// <remarks>*only exact match</remarks>
        string? UniqueId { get; }

        /// <summary>
        ///     (Optional) Text filter, for (src or dst or cnum)
        /// </summary>
        string? Filter { get; }

        IEnumerable<string>? Tags { get; }

        TimeSpan? TimeOut { get; }
    }
}
