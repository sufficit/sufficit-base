using System.Text.Json.Serialization;

namespace Sufficit.Gateway.ReceitaFederal
{
    public class Activity
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("default")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Default {get; set; }
    }
}