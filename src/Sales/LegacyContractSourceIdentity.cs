using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Sufficit.Sales
{
    /// <summary>Upgrades only proven legacy identities; display-name equality alone is insufficient.</summary>
    public static class LegacyContractSourceIdentity
    {
        public static bool CanUpgrade(Contract current, Contract desired)
        {
            if (current.Source != ContractSource.LegacySales || desired.Source != ContractSource.LegacySales
                || current.AutomationEnabled || current.ContextId != desired.ContextId
                || string.IsNullOrWhiteSpace(current.SourceKey)) return false;
            if (IsWhatsApp(current) && IsWhatsApp(desired))
                return desired.SourceKey == current.SourceKey + "|WHATSAPP";
            // Older hosting imports used one key per customer. Preserve the contract ID
            // only when the old key, named instance and new derived key all agree.
            // Other instances and source-less imports must never be adopted by this rule.
            if (current.Title != Constants.SERVICE_CHATWOOT_HOSTING
                || desired.Title != current.Title || string.IsNullOrWhiteSpace(current.Extra)
                || !string.Equals(current.Extra.Trim(), desired.Extra?.Trim(), StringComparison.OrdinalIgnoreCase)
                || current.Key != desired.Key) return false;
            var prefix = $"{current.ContextId:N}|{Constants.SERVICE_CHATWOOT_HOSTING}|";
            if (current.SourceKey != prefix) return false;
            using var sha = SHA256.Create();
            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(current.Extra.Trim().ToUpperInvariant()));
            return desired.SourceKey == prefix + "HOSTING:" + string.Concat(hash.Take(12).Select(b => b.ToString("x2")));
        }

        private static bool IsWhatsApp(Contract item)
            => item.Title == Constants.SERVICE_TRUNK_INBOUND
                && (item.Extra?.TrimStart().StartsWith("WHAT:", StringComparison.OrdinalIgnoreCase) == true
                    || item.Extra?.TrimStart().StartsWith("WHATSAPP:", StringComparison.OrdinalIgnoreCase) == true);
    }
}
