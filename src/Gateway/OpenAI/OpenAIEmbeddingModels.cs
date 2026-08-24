using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.OpenAI
{
    public sealed class OpenAIEmbeddingRequest
    {
        [JsonPropertyName("input")]
        public object? Input { get; set; }

        [JsonPropertyName("model")]
        public string? Model { get; set; }

        [JsonPropertyName("encoding_format")]
        public string? EncodingFormat { get; set; }

        [JsonPropertyName("dimensions")]
        public int? Dimensions { get; set; }

        [JsonPropertyName("user")]
        public string? User { get; set; }
    }

    public sealed class OpenAIEmbeddingResponse
    {
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("data")]
        public OpenAIEmbeddingData[] Data { get; set; } = Array.Empty<OpenAIEmbeddingData>();

        [JsonPropertyName("model")]
        public string? Model { get; set; }

        [JsonPropertyName("usage")]
        public OpenAIEmbeddingUsage Usage { get; set; } = new OpenAIEmbeddingUsage();
    }

    public sealed class OpenAIEmbeddingData
    {
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("embedding")]
        public float[] Embedding { get; set; } = Array.Empty<float>();

        [JsonPropertyName("index")]
        public int Index { get; set; }
    }

    public sealed class OpenAIEmbeddingUsage
    {
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }

        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }
}
