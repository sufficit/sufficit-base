using System;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Canonical technical ids exposed to Asterisk for PJSIP runtime objects.
    /// The contract is explicit: a short prefix, the separator, and a GUID payload.
    /// </summary>
    public static class PJSIPRuntimeId
    {
        public const char Separator = '-';

        // User endpoints must keep a single runtime identity across endpoint/AOR/auth.
        // Standard SIP softphones usually expose only one logical "user/account" field
        // for REGISTER, so splitting a user into uep/uao/uau makes the registrar lose the
        // effective AOR during the authenticated REGISTER. Interconnections do not have
        // that constraint, so they keep explicit object prefixes.
        //
        // The old user prefixes remain declared only so the parser can understand ids that
        // may still appear in migration tooling or stale caches. Builders no longer emit
        // those prefixes for ramais; raw GUID is now the canonical runtime id for users.
        public const string UserEndpointPrefix = "uep";
        public const string UserAorPrefix = "uao";
        public const string UserAuthPrefix = "uau";

        public const string InterconnectionEndpointPrefix = "xep";
        public const string InterconnectionAorPrefix = "xao";
        public const string InterconnectionAuthPrefix = "xau";
        public const string InterconnectionIdentifyPrefix = "xid";
        public const string InterconnectionRegistrationPrefix = "xre";

        public static string BuildUserEndPointId(Guid id)
            => BuildUserRuntimeId(id);

        public static string BuildUserAorId(Guid id)
            => BuildUserRuntimeId(id);

        public static string BuildUserAuthId(Guid id)
            => BuildUserRuntimeId(id);

        // Canonical runtime id for ramais. The registrar must see the same identifier in
        // endpoint, AOR and auth, so we intentionally expose the raw GUID payload here.
        public static string BuildUserRuntimeId(Guid id)
            => id.ToString("N");

        public static string BuildInterconnectionEndPointId(Guid id)
            => Build(InterconnectionEndpointPrefix, id);

        public static string BuildInterconnectionAorId(Guid id)
            => Build(InterconnectionAorPrefix, id);

        public static string BuildInterconnectionAuthId(Guid id)
            => Build(InterconnectionAuthPrefix, id);

        public static string BuildInterconnectionIdentifyId(Guid id)
            => Build(InterconnectionIdentifyPrefix, id);

        public static string BuildInterconnectionRegistrationId(Guid id)
            => Build(InterconnectionRegistrationPrefix, id);

        public static bool TryParseUserEndPointId(string? value, out Guid id)
            => TryParseUserRuntimeId(value, out id);

        public static bool TryParseUserAorId(string? value, out Guid id)
            => TryParseUserRuntimeId(value, out id);

        public static bool TryParseUserAuthId(string? value, out Guid id)
            => TryParseUserRuntimeId(value, out id);

        public static bool TryParseUserRuntimeId(string? value, out Guid id)
        {
            id = Guid.Empty;
            if (string.IsNullOrWhiteSpace(value))
                return false;

            var candidate = value.Trim();
            if (Guid.TryParseExact(candidate, "N", out id))
                return true;

            return TryParsePrefixed(candidate, UserEndpointPrefix, out id)
                || TryParsePrefixed(candidate, UserAorPrefix, out id)
                || TryParsePrefixed(candidate, UserAuthPrefix, out id);
        }

        public static bool TryParseInterconnectionEndPointId(string? value, out Guid id)
            => TryParse(value, InterconnectionEndpointPrefix, out id);

        public static bool TryParseInterconnectionAorId(string? value, out Guid id)
            => TryParse(value, InterconnectionAorPrefix, out id);

        public static bool TryParseInterconnectionAuthId(string? value, out Guid id)
            => TryParse(value, InterconnectionAuthPrefix, out id);

        public static bool TryParseInterconnectionIdentifyId(string? value, out Guid id)
            => TryParse(value, InterconnectionIdentifyPrefix, out id);

        public static bool TryParseInterconnectionRegistrationId(string? value, out Guid id)
            => TryParse(value, InterconnectionRegistrationPrefix, out id);

        public static bool IsUserEndPointId(string? value)
            => TryParseUserEndPointId(value, out _);

        public static bool IsUserAorId(string? value)
            => TryParseUserAorId(value, out _);

        public static bool IsUserAuthId(string? value)
            => TryParseUserAuthId(value, out _);

        public static bool IsUserRuntimeId(string? value)
            => TryParseUserRuntimeId(value, out _);

        public static bool IsInterconnectionEndPointId(string? value)
            => TryParseInterconnectionEndPointId(value, out _);

        public static bool IsInterconnectionAorId(string? value)
            => TryParseInterconnectionAorId(value, out _);

        public static bool IsInterconnectionAuthId(string? value)
            => TryParseInterconnectionAuthId(value, out _);

        public static bool IsInterconnectionIdentifyId(string? value)
            => TryParseInterconnectionIdentifyId(value, out _);

        public static bool IsInterconnectionRegistrationId(string? value)
            => TryParseInterconnectionRegistrationId(value, out _);

        private static string Build(string prefix, Guid id)
            => $"{prefix}{Separator}{id:N}";

        private static bool TryParse(string? value, string prefix, out Guid id)
        {
            id = Guid.Empty;
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return TryParsePrefixed(value.Trim(), prefix, out id);
        }

        private static bool TryParsePrefixed(string value, string prefix, out Guid id)
        {
            id = Guid.Empty;

            if (!value.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return false;

            if (value.Length <= prefix.Length || value[prefix.Length] != Separator)
                return false;

            var guidPart = value.Substring(prefix.Length + 1);
            return guidPart.Length == 32 && Guid.TryParseExact(guidPart, "N", out id);
        }
    }
}
