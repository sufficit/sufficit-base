using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Cadences
{
    /// <summary>Structural checks shared by API and UI. Messages are user facing (pt-BR).</summary>
    public static class CadenceValidator
    {
        public const int MaxOffsetDays = 365;

        public static readonly IReadOnlyList<string> KnownChannels = new[] { "whatsapp", "email", "sms" };

        public static IReadOnlyList<string> Validate(Cadence cadence)
        {
            if (cadence == null) throw new ArgumentNullException(nameof(cadence));

            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(cadence.Name))
                errors.Add("Informe o nome da régua.");
            if (!CadenceModules.All.ContainsKey(cadence.Module ?? ""))
                errors.Add($"Módulo desconhecido \"{cadence.Module}\".");
            if (!CadenceAnchors.All.ContainsKey(cadence.Anchor ?? ""))
                errors.Add($"Referência de data desconhecida \"{cadence.Anchor}\".");

            if (cadence.Status == CadenceStatus.Active)
            {
                if (cadence.Steps.Count == 0)
                    errors.Add("Uma régua ativa precisa de pelo menos uma etapa.");
                if (cadence.Targets.Count == 0)
                    errors.Add("Uma régua ativa precisa de pelo menos um alvo.");
                if (string.IsNullOrWhiteSpace(cadence.ChangeReason))
                    errors.Add("Explique o motivo da alteração; régua ativa afeta clientes.");
            }

            foreach (var target in cadence.Targets)
            {
                if (CadenceTargetTypes.Find(target.TargetType) == null)
                    errors.Add($"Tipo de alvo desconhecido \"{target.TargetType}\".");
                if (string.IsNullOrWhiteSpace(target.TargetId))
                    errors.Add($"Alvo \"{target.Title ?? target.TargetType}\" sem identificador.");
            }

            var ordered = Ordered(cadence.Steps);
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var terminated = false;
            for (var index = 0; index < ordered.Count; index++)
            {
                var step = ordered[index];
                var label = $"D{Format(step.OffsetDays)}";
                if (Math.Abs(step.OffsetDays) > MaxOffsetDays)
                    errors.Add($"{label}: o prazo deve ficar entre -{MaxOffsetDays} e +{MaxOffsetDays} dias.");

                var action = CadenceActions.Find(step.Action);
                if (action == null)
                {
                    errors.Add($"{label}: ação desconhecida \"{step.Action}\".");
                    continue;
                }
                if (action.Module.Length > 0 && !string.Equals(action.Module, cadence.Module, StringComparison.OrdinalIgnoreCase))
                    errors.Add($"{label}: \"{action.Title}\" é do módulo {CadenceModules.Title(action.Module)}.");

                if (!seen.Add($"{step.OffsetDays}|{action.Key}"))
                    errors.Add($"{label}: \"{action.Title}\" repetida no mesmo dia.");

                if (!string.IsNullOrWhiteSpace(step.Condition) && !CadenceConditions.IsKnown(step.Condition))
                    errors.Add($"{label}: condição desconhecida \"{step.Condition}\".");

                var channels = SplitChannels(step.Channels);
                if (action.UsesChannels && channels.Count == 0)
                    errors.Add($"{label}: escolha ao menos um canal para \"{action.Title}\".");
                foreach (var channel in channels.Where(c => !KnownChannels.Contains(c)))
                    errors.Add($"{label}: canal desconhecido \"{channel}\".");

                if (action.Requires != null && !ordered.Take(index).Any(s => string.Equals(s.Action, action.Requires, StringComparison.OrdinalIgnoreCase)))
                    errors.Add($"{label}: \"{action.Title}\" exige \"{CadenceActions.Find(action.Requires)?.Title ?? action.Requires}\" antes.");

                if (terminated && action.Category == CadenceActionCategory.Restriction)
                    errors.Add($"{label}: \"{action.Title}\" depois do encerramento não tem efeito.");
                terminated |= action.Category == CadenceActionCategory.Termination;
            }

            return errors;
        }

        public static List<CadenceStep> Ordered(IEnumerable<CadenceStep> steps)
            => steps.OrderBy(s => s.OffsetDays).ThenBy(s => s.Order).ToList();

        public static IReadOnlyList<string> SplitChannels(string? channels)
            => string.IsNullOrWhiteSpace(channels)
                ? Array.Empty<string>()
                : channels!.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c.Trim().ToLowerInvariant()).Distinct().ToArray();

        /// <summary>"-3", "0", "+5".</summary>
        public static string Format(int offsetDays) => offsetDays > 0 ? "+" + offsetDays : offsetDays.ToString();
    }
}
