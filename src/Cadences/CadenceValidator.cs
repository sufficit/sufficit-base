using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Cadences
{
    /// <summary>Structural checks shared by API and UI. Messages are user facing (pt-BR).</summary>
    public static class CadenceValidator
    {
        public const int MaxOffsetDays = 365;

        /// <param name="knownKeys">Milestone keys contributed by the modules; null skips the catalog check.</param>
        public static IReadOnlyList<string> Validate(Cadence cadence, ISet<string>? knownKeys)
        {
            if (cadence == null) throw new ArgumentNullException(nameof(cadence));

            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(cadence.Name))
                errors.Add("Informe o nome da régua.");

            if (cadence.Status == CadenceStatus.Active)
            {
                if (cadence.Milestones.Count == 0)
                    errors.Add("Uma régua ativa precisa de pelo menos um marco.");
                if (string.IsNullOrWhiteSpace(cadence.ChangeReason))
                    errors.Add("Explique o motivo da alteração; régua ativa afeta clientes.");
            }

            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var milestone in CadenceSchedule.Ordered(cadence.Milestones))
            {
                var label = $"D{CadenceSchedule.Format(milestone.OffsetDays)}";
                if (string.IsNullOrWhiteSpace(milestone.Key))
                    errors.Add($"{label}: escolha o marco.");
                else if (knownKeys != null && !knownKeys.Contains(milestone.Key))
                    errors.Add($"{label}: nenhum módulo reconhece o marco \"{milestone.Key}\".");
                if (Math.Abs(milestone.OffsetDays) > MaxOffsetDays)
                    errors.Add($"{label}: o prazo deve ficar entre -{MaxOffsetDays} e +{MaxOffsetDays} dias.");
                if (!string.IsNullOrWhiteSpace(milestone.Key) && !seen.Add(milestone.Key))
                    errors.Add($"{label}: o marco \"{milestone.Key}\" aparece mais de uma vez.");
            }
            return errors;
        }
    }
}
