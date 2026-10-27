using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Cadences
{
    /// <summary>Structural checks shared by API and UI. Messages are user facing (pt-BR).</summary>
    public static class CadenceValidator
    {
        public const int MaxOffsetDays = 365;

        /// <param name="catalog">Subjects and milestones contributed by the modules; null skips the catalog checks.</param>
        public static IReadOnlyList<string> Validate(Cadence cadence, CadenceCatalog? catalog)
        {
            if (cadence == null) throw new ArgumentNullException(nameof(cadence));

            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(cadence.Name))
                errors.Add("Informe o nome da régua.");

            if (catalog != null && !string.IsNullOrWhiteSpace(cadence.SubjectType)
                && !catalog.Subjects.Any(s => string.Equals(s.Key, cadence.SubjectType, StringComparison.OrdinalIgnoreCase)))
                errors.Add($"Nenhum módulo abre casos do assunto \"{cadence.SubjectType}\".");

            if (cadence.Status == CadenceStatus.Active)
            {
                if (string.IsNullOrWhiteSpace(cadence.SubjectType))
                    errors.Add("Escolha o assunto da régua (o que os casos representam).");
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
                else if (catalog != null)
                {
                    var definition = catalog.Milestones.FirstOrDefault(m => string.Equals(m.Key, milestone.Key, StringComparison.OrdinalIgnoreCase));
                    if (definition == null)
                        errors.Add($"{label}: nenhum módulo reconhece o marco \"{milestone.Key}\".");
                    else if (!definition.Supports(cadence.SubjectType))
                        errors.Add($"{label}: \"{definition.Title}\" ({definition.Module}) não atua sobre o assunto desta régua.");
                }
                if (Math.Abs(milestone.OffsetDays) > MaxOffsetDays)
                    errors.Add($"{label}: o prazo deve ficar entre -{MaxOffsetDays} e +{MaxOffsetDays} dias.");
                if (!string.IsNullOrWhiteSpace(milestone.Key) && !seen.Add(milestone.Key))
                    errors.Add($"{label}: o marco \"{milestone.Key}\" aparece mais de uma vez.");
            }
            return errors;
        }
    }
}
