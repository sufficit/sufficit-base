using System;
using System.Collections.Generic;

namespace Sufficit.AI
{
    /// <summary>
    ///     Administrable behaviour of the AI assistant: the bootstrap prompt sent before
    ///     anything else and the guardrails enforced on every request. Shared contract of
    ///     the endpoints API (persistence), the sufficit-client sections and the Blazor UI.
    ///     Replaces the sufficit-ai memory observations, whose summary length was never
    ///     designed to hold full prompts.
    /// </summary>
    public sealed class AIAssistantSettings
    {
        /// <summary>First system instruction sent on every request, before the guardrails.</summary>
        public string? BootstrapPrompt { get; set; }

        public List<AIAssistantGuardrail> Guardrails { get; set; } = new();
    }

    /// <summary>A phrase enforced on the model in every request.</summary>
    public sealed class AIAssistantGuardrail
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Text { get; set; } = string.Empty;

        public bool Enabled { get; set; } = true;

        /// <summary>Ascending position among the guardrails.</summary>
        public int Order { get; set; }
    }
}
