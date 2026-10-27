using System;
using System.Collections.Generic;

namespace Sufficit.Cadences
{
    /// <summary>
    ///     Facts a step can depend on: a step with a condition is skipped when the consumer reports that fact as true
    ///     for the case (<see cref="CadenceCase.Facts"/>).
    /// </summary>
    public static class CadenceConditions
    {
        /// <summary>Customer has automatic payment (authorized recurring card / active subscription).</summary>
        public const string AutomaticPayment = "automatic-payment";

        /// <summary>Message was already delivered and read for this case.</summary>
        public const string ContactConfirmed = "contact-confirmed";

        /// <summary>Customer has no contact for the step channels.</summary>
        public const string NoContact = "no-contact";

        public static IReadOnlyDictionary<string, string> All { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            [AutomaticPayment] = "Pular se houver pagamento automático",
            [ContactConfirmed] = "Pular se o contato já foi confirmado",
            [NoContact] = "Pular se não houver contato",
        };

        public static bool IsKnown(string? key) => !string.IsNullOrWhiteSpace(key) && All.ContainsKey(key!.Trim());
    }
}
