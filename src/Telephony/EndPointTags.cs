using System;
using System.Collections.Generic;
using System.Linq;
namespace Sufficit.Telephony;

/// <summary>General endpoint classification. Reserved keys are stable and available in every context.</summary>
public static class EndPointTags
{
    public static string ReservedKey(Guid id) => "system:" + id.ToString("D");
    public static string[] Normalize(IEnumerable<string> tags)
    {
        if (tags == null) throw new ArgumentException("Informe as tags; use uma lista vazia para remover todas.");
        var values = tags.Select(x => (x ?? "").Trim().Normalize()).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToArray();
        if (values.Length > 50 || values.Any(x => x.Length == 0 || x.Length > 80 || x.Any(char.IsControl)))
            throw new ArgumentException("Use até 50 tags, cada uma com 1 a 80 caracteres sem controles.");
        foreach (var value in values.Where(x => x.StartsWith("system:", StringComparison.OrdinalIgnoreCase)))
            if (!EndPointSupportRoles.Catalog.Any(r => ReservedKey(r.Id) == value))
                throw new ArgumentException("Tag reservada desconhecida.");
        return values;
    }
    public static Guid[] Roles(IEnumerable<string> tags) => EndPointSupportRoles.Catalog
        .Where(r => tags.Contains(ReservedKey(r.Id), StringComparer.Ordinal)).Select(r => r.Id).ToArray();
    public static string[] Custom(IEnumerable<string> tags) => tags.Where(x => !x.StartsWith("system:", StringComparison.OrdinalIgnoreCase)).ToArray();
    public static string[] Combine(IEnumerable<string> custom, IEnumerable<Guid> roles)
        => Normalize(custom.Concat(roles.Select(ReservedKey)));
}
