using System.Text.Json.Serialization;

namespace Sufficit.Resources.ReceitaFederal
{
    public class Person
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("cpf")]
        public string? Cpf { get; set; }

        [JsonPropertyName("dataNascimento")]
        public string? DataNascimento { get; set; }

        [JsonPropertyName("situacaoCadastral")]
        public string? SituacaoCadastral { get; set; }

        [JsonPropertyName("dataInscricao")]
        public string? DataInscricao { get; set; }

        [JsonPropertyName("digitoVerificador")]
        public string? DigitoVerificador { get; set; }
    }
}
