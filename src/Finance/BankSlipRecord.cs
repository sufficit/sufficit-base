using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    public class BankSlipRecord  : BankSlipInfo
    {
        #region Obsolete

        [MaxLength(3)]
        public string Banco { get; set; } = string.Empty;

        public string NossoNumero { get; set; } = string.Empty;
        public string NumeroDoc { get; set; } = string.Empty;

        public string CedenteNome { get; set; } = string.Empty;
        public string CedenteCPFCNPJ { get; set; } = string.Empty;
        public string CedenteCodigo { get; set; } = string.Empty;
        public string CedenteAgencia { get; set; } = string.Empty;
        public string CedenteConta { get; set; } = string.Empty;

        public string? SacadoCPFCNPJ { get; set; }
        public string? SacadoNome { get; set; }
        public string? SacadoEndLogradouro { get; set; }
        public string? SacadoEndBairro { get; set; }
        public string? SacadoEndCEP { get; set; }
        public string? SacadoEndCidade { get; set; }
        public string? SacadoEndUF { get; set; }


        #endregion

        /// <summary>
        ///     Extra informations, cancelled reason or any other
        /// </summary>
        [JsonPropertyOrder(10)]
        [JsonPropertyName("extra")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Extra { get; set; } = string.Empty;
    }
}
