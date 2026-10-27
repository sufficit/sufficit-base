using System;
using System.Collections.Generic;

namespace Sufficit.Sales
{
    /// <summary>Known step conditions. A step with a condition is skipped when the condition says so.</summary>
    public static class ServiceRuleConditions
    {
        /// <summary>Skip when the customer has automatic payment (authorized recurring card / active subscription).</summary>
        public const string SkipWhenAutomaticPayment = "skip-when-automatic-payment";

        public static IReadOnlyDictionary<string, string> All { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            [SkipWhenAutomaticPayment] = "Pular se houver pagamento automático",
        };

        public static bool IsKnown(string? key) => !string.IsNullOrWhiteSpace(key) && All.ContainsKey(key!.Trim());
    }
}
