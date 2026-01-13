using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.ReceitaFederal
{
    public class Person
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
        
        [JsonPropertyName("alias")]
        public string? Alias { get; set; }

        [JsonPropertyName("document")]
        public string? Document { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("incorporation")]
        public DateTime? Incorporation { get; set; }

        [JsonPropertyName("verificationDigit")]
        public string? VerificationDigit { get; set; }

        [JsonPropertyName("address")]
        public Address? Address { get; set; }

        [JsonPropertyName("partners")]
        public Partner[]? Partners { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("nature")]
        public string? Nature { get; set; }

        [JsonPropertyName("activities")]
        public Activity[]? Activities { get; set; }

        [JsonPropertyName("size")]
        public string? Size { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("capital")]
        public decimal? Capital { get; set; }
    }
}