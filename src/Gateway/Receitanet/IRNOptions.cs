using System;

namespace Sufficit.Gateway.ReceitaNet
{
    public interface IRNOptions
    {
        /// <summary>
        /// ID do cliente ao qual se aplica 
        /// </summary>
        Guid IDContext { get; }

        /// <summary>
        /// Titulo para identificação no portal, caso haja mais de um (improvavel)
        /// </summary>
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

        /// <summary>
        /// Locutor a ser usado como principal para as falas
        /// </summary>
        int Announcer { get; }
    }
}
