using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.MagnusBilling
{
    /// <summary>
    /// Standard MagnusBilling API request structure
    /// Compatible with original MagnusBilling API format
    /// </summary>
    public class MagnusBillingRequest
    {
        #region Authentication

        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; } = string.Empty;

        [JsonPropertyName("api_secret")]
        public string ApiSecret { get; set; } = string.Empty;

        #endregion

        #region Pagination

        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 20;

        [JsonPropertyName("start")]
        public int Start { get; set; } = 0;

        #endregion

        #region Filtering

        [JsonPropertyName("filter")]
        public MagnusBillingFilter[]? Filter { get; set; }

        [JsonPropertyName("sort")]
        public string? Sort { get; set; }

        [JsonPropertyName("dir")]
        public string? Direction { get; set; } = "ASC";

        #endregion

        #region Entity Specific Fields

        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        #endregion
    }
}