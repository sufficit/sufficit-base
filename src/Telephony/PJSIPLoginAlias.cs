using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Short PJSIP login alias of an extension, for devices that cannot hold the 32-character
    ///     GUID user name. Numeric only (owner decision 2026-11-18): Cisco and other phones treat the
    ///     line name as a directory number and answer 404 to INVITEs addressed to an alphanumeric
    ///     user. Format: 10 digits in 0010000000..0099999999 ("00" + 8 digits, third digit 1-9),
    ///     disjoint from the legacy extension titles, which never exceed 0009999999.
    ///     Deterministic: derived from SHA-256 of the GUID. The GUID stays the canonical identity;
    ///     the alias is persisted as an <see cref="EndPointAlias"/> of kind
    ///     <see cref="EndPointAliasKind.Login"/>.
    /// </summary>
    public static class PJSIPLoginAlias
    {
        public const int Length = 10;

        /// <summary>First value of the login range; everything below belongs to legacy titles.</summary>
        public const ulong RangeStart = 10_000_000UL;

        /// <summary>Size of the login range (0010000000..0099999999).</summary>
        public const ulong RangeSize = 90_000_000UL;

        private static readonly Regex Pattern = new Regex("^00[1-9][0-9]{7}$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>True when <paramref name="value"/> is in the short login range.</summary>
        public static bool IsShortAlias(string? value) => value != null && Pattern.IsMatch(value);

        /// <summary>
        ///     Short alias of <paramref name="endPointId"/>. <paramref name="attempt"/> &gt; 0 derives an
        ///     alternative value, used only when the first one is already taken.
        /// </summary>
        public static string Create(Guid endPointId, int attempt = 0)
        {
            if (endPointId == Guid.Empty) throw new ArgumentException("endpoint id is required", nameof(endPointId));
            if (attempt < 0) throw new ArgumentOutOfRangeException(nameof(attempt));

            var input = endPointId.ToString("N") + (attempt == 0 ? string.Empty : ":" + attempt);
            byte[] hash;
            using (var sha = SHA256.Create())
                hash = sha.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input));

            ulong value = 0;
            for (var i = 0; i < 8; i++) value = (value << 8) | hash[i];

            return (RangeStart + value % RangeSize).ToString("D" + Length, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
