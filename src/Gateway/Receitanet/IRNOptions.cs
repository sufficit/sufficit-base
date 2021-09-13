using System;
using System.ComponentModel.DataAnnotations;

namespace Sufficit.Gateway.Receitanet
{
    public interface IRNOptions
    {
        /// <summary>
        /// ID do cliente ao qual se aplica 
        /// </summary>
        Guid IDContext { get; }

        string Title { get; }

        /// <summary>
        /// Habilitado ?
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// Fichas de acesso <br />
        /// </summary>
        /// <example>"5e876bd7-d242-4aec-a72c-abeaab2f2817" -> default token</example>
        string[] Tokens { get; }

        /// <summary>
        /// Falar o protocolo sempre que disponível ?
        /// </summary>
        bool Protocol { get; }

        /// <summary>
        /// Processar etapa de envio de fatura mesmo ainda dentro do vencimento
        /// </summary>
        bool ForceBilling { get; }
    }
}
