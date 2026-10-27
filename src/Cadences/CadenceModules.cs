using System;
using System.Collections.Generic;

namespace Sufficit.Cadences
{
    /// <summary>Modules that own cadences. A module filters the UI and decides which targets and actions make sense.</summary>
    public static class CadenceModules
    {
        public const string Sales = "sales";
        public const string Notification = "notification";
        public const string Telephony = "telephony";
        public const string Finance = "finance";
        public const string Hermes = "hermes";
        public const string Tasks = "tasks";

        public static IReadOnlyDictionary<string, string> All { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            [Sales] = "Vendas",
            [Notification] = "Notificações",
            [Telephony] = "Telefonia",
            [Finance] = "Financeiro",
            [Hermes] = "Hermes",
            [Tasks] = "Atividades",
        };

        public static string Title(string? key) => key != null && All.TryGetValue(key, out var title) ? title : key ?? "";
    }
}
