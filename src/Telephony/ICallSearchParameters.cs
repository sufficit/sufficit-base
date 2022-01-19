using System;
using System.Collections.Generic;
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
        /// (Opicional) Data/Hora de término do intervalo de busca <br />
        /// Caso não seja preenchido, o resultado trará todos os registro apartir da data/hora de início
        /// </summary>
        DateTime? End { get; }

        /// <summary>
        /// (Opicional) Traz os resultados no seguinte fuso / região de horário <br />
        /// O padrão é trazer tudo em GMT
        /// </summary>
        RegionEnum? Region { get; }

        /// <summary>
        /// (Opicional) Filtra a pesquisa por apenas as DIDs selecionadas, portanto, somente chamadas de entrada
        /// </summary>
        string[] DIDs { get; }

        /// <summary>
        /// (Opicional) Filtra por apenas chamadas tarifadas, que tiveram ou podem gerar custos <br />
        /// Valor padrão (false)
        /// </summary>
        bool Billed { get; }

        /// <summary>
        /// (Opicional) Filtra por apenas chamadas atendidas, que foram marcadas como atendidas pela central telefonica
        /// </summary>
        bool Answered { get; }

        /// <summary>
        /// (Opicional) Limite de resultados na consulta (aproximado)
        /// </summary>
        int Limit { get; }
    }
}
