using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.MagnusBilling
{
    /// <summary>
    /// Standard MagnusBilling API response structure
    /// Compatible with original MagnusBilling API format
    /// </summary>
    /// <typeparam name="T">Type of data in rows</typeparam>
    public class MagnusBillingResponse<T>
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; } = true;

        [JsonPropertyName("total")]
        public long Total { get; set; }

        [JsonPropertyName("rows")]
        public T[] Rows { get; set; } = Array.Empty<T>();

        [JsonPropertyName("errors")]
        public string? Errors { get; set; }

        [JsonPropertyName("msg")]
        public string? Message { get; set; }
    }

    /// <summary>
    /// Simple MagnusBilling response without generic type
    /// </summary>
    public class MagnusBillingResponse : MagnusBillingResponse<object>
    {
    }
}