using System.Text.Json.Serialization;

namespace Sufficit.Gateway.MagnusBilling
{
    /// <summary>
    /// MagnusBilling authentication response
    /// </summary>
    public class MagnusBillingAuthResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("id_user")]
        public string? IdUser { get; set; }

        [JsonPropertyName("id_group")]
        public string? IdGroup { get; set; }

        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("usertype")]
        public string? UserType { get; set; }

        [JsonPropertyName("sessionid")]
        public string? SessionId { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("errors")]
        public string? Errors { get; set; }
    }
}