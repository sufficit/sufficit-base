using System;

namespace Sufficit.Gateway.OpenAI
{
    /// <summary>
    /// OpenAI-compatible models list response
    /// </summary>
    public class OpenAIModelsResponse
    {

        public string Object { get; set; } = "list";

        public OpenAIModel[] Data { get; set; } = Array.Empty<OpenAIModel>();

    }
}
