using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sufficit.Gateway.Receitanet
{
    public class RNOptions : IRNOptions
    {
        /// <summary>
        /// ID do aplicativo no sistema <br />
        /// Identificador para diferenciar nos relatórios
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// ID do cliente ao qual se aplica 
        /// </summary>
        public Guid IDContext { get; set; }

        [StringLength(40)]
        public string Title { get; set; }

        /// <summary>
        /// Habilitado ?
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Fichas de acesso <br />
        /// </summary>
        /// <example>"5e876bd7-d242-4aec-a72c-abeaab2f2817" -> default token</example>
        [StringLength(200)]
        public string[] Tokens { get; set; }

        /// <summary>
        /// Falar o protocolo sempre que disponível ?
        /// </summary>
        public bool Protocol { get; set; }

        /// <summary>
        /// Processar etapa de envio de fatura mesmo ainda dentro do vencimento
        /// </summary>
        public bool ForceBilling { get; set; }

        /// <summary>
        /// Data / Hora da ultima atualização
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Updated { get; }
    }
}
