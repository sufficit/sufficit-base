using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Telephony.InterConnection
{
    /// <summary>
    ///     Resolves which canonical credential row should be used by each
    ///     interconnection leg. The split between inbound and outbound is real,
    ///     but the runtime should only diverge when the selected credential rows
    ///     are actually different. When both legs point to the same credential,
    ///     callers should reuse the same technical auth object instead of
    ///     duplicating it with two ids.
    /// </summary>
    public static class InterconnectionCredentialSelector
    {
        public static InterconnectionCredential[] GetEnabledCredentials(Interconnection interconnection)
            => (interconnection?.Credentials ?? Array.Empty<InterconnectionCredential>())
                .Where(item => item.Id != Guid.Empty && item.Enabled && item.DeletedAtUtc == null)
                .OrderBy(item => item.CreatedAtUtc)
                .ThenBy(item => item.Id)
                .ToArray();

        public static bool HasInlineCredentials(Interconnection interconnection)
            => interconnection != null
                && !string.IsNullOrWhiteSpace(interconnection.Username)
                && !string.IsNullOrWhiteSpace(interconnection.Secret);

        public static InterconnectionCredential? ResolveInbound(Interconnection interconnection)
            => Resolve(interconnection, interconnection?.InboundCredentialId);

        public static InterconnectionCredential? ResolveOutbound(Interconnection interconnection)
            => Resolve(interconnection, interconnection?.OutboundCredentialId);

        public static InterconnectionCredential? ResolveOutbound(Interconnection interconnection, InterconnectionRegistration? registration)
            => Resolve(interconnection, registration?.OutboundCredentialId, interconnection?.OutboundCredentialId);

        public static IReadOnlyCollection<InterconnectionCredential> ResolveDistinctEffectiveCredentials(Interconnection interconnection)
        {
            var result = new Dictionary<Guid, InterconnectionCredential>();
            AddDistinct(result, ResolveInbound(interconnection));
            AddDistinct(result, ResolveOutbound(interconnection));
            return result.Values.ToArray();
        }

        private static InterconnectionCredential? Resolve(Interconnection? interconnection, params Guid?[] preferredIds)
        {
            if (interconnection == null)
                return null;

            var enabledCredentials = GetEnabledCredentials(interconnection);
            foreach (var preferredId in preferredIds)
            {
                if (!preferredId.HasValue || preferredId.Value == Guid.Empty)
                    continue;

                var match = enabledCredentials.FirstOrDefault(item => item.Id == preferredId.Value);
                if (match != null)
                    return match;
            }

            return enabledCredentials.Length == 1 ? enabledCredentials[0] : null;
        }

        private static void AddDistinct(IDictionary<Guid, InterconnectionCredential> target, InterconnectionCredential? credential)
        {
            if (credential == null || credential.Id == Guid.Empty)
                return;

            target[credential.Id] = credential;
        }
    }
}
