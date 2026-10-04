using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.AI
{
    /// <summary>
    ///     Normalization and defaults shared by every reader and writer of
    ///     <see cref="AIAssistantSettings"/>: the endpoints API and the Blazor UI must
    ///     agree on trimming, ordering and the out-of-the-box guardrails.
    /// </summary>
    public static class AIAssistantSettingsNormalizer
    {
        /// <summary>Trims the prompt, drops empty guardrails and renumbers the order.</summary>
        public static void Normalize(AIAssistantSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            settings.BootstrapPrompt = string.IsNullOrWhiteSpace(settings.BootstrapPrompt)
                ? null
                : settings.BootstrapPrompt.Trim();

            settings.Guardrails ??= new List<AIAssistantGuardrail>();
            settings.Guardrails.RemoveAll(item => item == null || string.IsNullOrWhiteSpace(item.Text));

            var order = 0;
            foreach (var guardrail in settings.Guardrails.OrderBy(item => item.Order).ToList())
            {
                guardrail.Text = guardrail.Text.Trim();
                guardrail.Order = order++;
            }
        }

        /// <summary>Whether nothing meaningful was persisted yet.</summary>
        public static bool IsEmpty(AIAssistantSettings settings)
            => settings == null
               || (string.IsNullOrWhiteSpace(settings.BootstrapPrompt)
                   && (settings.Guardrails == null || settings.Guardrails.Count == 0));

        /// <summary>Defaults served while nothing was persisted yet.</summary>
        public static AIAssistantSettings CreateDefault()
        {
            var settings = new AIAssistantSettings();
            settings.Guardrails.Add(new AIAssistantGuardrail
            {
                Order = 0,
                Text = "Responda sempre em Markdown válido e enxuto: listas curtas, **negrito** só no essencial "
                     + "e blocos de código apenas para código ou identificadores."
            });
            settings.Guardrails.Add(new AIAssistantGuardrail
            {
                Order = 1,
                Text = "Estilo caveman: máxima informação no mínimo de palavras. Sem preâmbulo, sem repetir a "
                     + "pergunta, sem se desculpar. Frases curtas e diretas, mantendo precisão técnica."
            });
            return settings;
        }
    }
}
