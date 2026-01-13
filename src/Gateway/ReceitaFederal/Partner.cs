using System.Text.Json.Serialization;

namespace Sufficit.Gateway.ReceitaFederal
{
    public class Partner
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("document")]
        public string? Document { get; set; }

        [JsonPropertyName("qualification")]
        public string? Qualification { get; set; }

        [JsonPropertyName("entryDate")]
        public string? EntryDate { get; set; }
    }
}