#if NETSTANDARD2_0
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    /// <summary>
    /// Binary compatibility base for the last EFData netstandard2.0 asset.
    /// </summary>
    [Obsolete("Use LegacyBankSlipInfo.")]
    public class BankSlipInfo : LegacyBankSlipInfo
    {
    }

    /// <summary>
    /// Binary compatibility record for the last EFData netstandard2.0 asset.
    /// </summary>
    [Obsolete("Use LegacyBankSlipRecord.")]
    public class BankSlipRecord : BankSlipInfo
    {
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

        [JsonPropertyOrder(10)]
        [JsonPropertyName("extra")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Extra { get; set; } = string.Empty;
    }
}
#endif
