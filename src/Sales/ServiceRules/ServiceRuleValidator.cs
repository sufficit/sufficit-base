using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Sales
{
    /// <summary>Structural checks shared by API and UI. Messages are user facing (pt-BR).</summary>
    public static class ServiceRuleValidator
    {
        public const int MaxOffsetDays = 365;

        public static readonly IReadOnlyList<string> KnownChannels = new[] { "whatsapp", "email", "sms" };

        public static IReadOnlyList<string> Validate(ServiceRule rule)
        {
            if (rule == null) throw new ArgumentNullException(nameof(rule));

            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(rule.Name))
                errors.Add("Informe o nome da régua.");

            if (rule.Status == ServiceRuleStatus.Active)
            {
                if (rule.Steps.Count == 0)
                    errors.Add("Uma régua ativa precisa de pelo menos uma etapa.");
                if (string.IsNullOrWhiteSpace(rule.ChangeReason))
                    errors.Add("Explique o motivo da alteração; régua ativa afeta clientes.");
            }

            var ordered = Ordered(rule.Steps);
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var terminated = false;
            for (var index = 0; index < ordered.Count; index++)
            {
                var step = ordered[index];
                var label = $"D{Format(step.OffsetDays)}";
                if (Math.Abs(step.OffsetDays) > MaxOffsetDays)
                    errors.Add($"{label}: o prazo deve ficar entre -{MaxOffsetDays} e +{MaxOffsetDays} dias.");

                var action = ServiceRuleActions.Find(step.Action);
                if (action == null)
                {
                    errors.Add($"{label}: ação desconhecida \"{step.Action}\".");
                    continue;
                }

                if (!seen.Add($"{step.OffsetDays}|{action.Key}"))
                    errors.Add($"{label}: \"{action.Title}\" repetida no mesmo dia.");

                if (!string.IsNullOrWhiteSpace(step.Condition) && !ServiceRuleConditions.IsKnown(step.Condition))
                    errors.Add($"{label}: condição desconhecida \"{step.Condition}\".");

                var channels = SplitChannels(step.Channels);
                if (action.UsesChannels && channels.Count == 0)
                    errors.Add($"{label}: escolha ao menos um canal para \"{action.Title}\".");
                foreach (var channel in channels.Where(c => !KnownChannels.Contains(c)))
                    errors.Add($"{label}: canal desconhecido \"{channel}\".");

                if (action.Requires != null && !ordered.Take(index).Any(s => string.Equals(s.Action, action.Requires, StringComparison.OrdinalIgnoreCase)))
                    errors.Add($"{label}: \"{action.Title}\" exige \"{ServiceRuleActions.Find(action.Requires)?.Title ?? action.Requires}\" antes.");

                if (terminated && action.Category == ServiceRuleActionCategory.Restriction)
                    errors.Add($"{label}: \"{action.Title}\" depois do encerramento não tem efeito.");
                terminated |= action.Category == ServiceRuleActionCategory.Termination;
            }

            return errors;
        }

        public static List<ServiceRuleStep> Ordered(IEnumerable<ServiceRuleStep> steps)
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
