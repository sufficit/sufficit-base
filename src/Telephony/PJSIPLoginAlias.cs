using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Short PJSIP login alias of an extension, for devices that cannot hold the 32-character
    ///     GUID user name. Deterministic: <c>p</c> + 9 characters derived from SHA-256 of the GUID,
    ///     over an alphabet without look-alike characters (no 0, 1, i, l, o), 10 characters total.
    ///     The GUID stays the canonical identity; the alias is persisted as an
    ///     <see cref="EndPointAlias"/> of kind <see cref="EndPointAliasKind.Login"/>.
    /// </summary>
    public static class PJSIPLoginAlias
    {
        public const string Prefix = "p";
        public const int Length = 10;
        public const string Alphabet = "23456789abcdefghjkmnpqrstuvwxyz";

        private static readonly Regex Pattern = new Regex("^p[2-9a-hjkmnp-z]{9}$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>True when <paramref name="value"/> has the short login alias shape.</summary>
        public static bool IsShortAlias(string? value) => value != null && Pattern.IsMatch(value);

        /// <summary>
        ///     Short alias of <paramref name="endPointId"/>. <paramref name="attempt"/> &gt; 0 derives an
        ///     alternative value, used only when the first one is already taken by another extension.
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

            var chars = new char[Length];
            chars[0] = Prefix[0];
            var radix = (ulong)Alphabet.Length;
            for (var i = Length - 1; i >= 1; i--)
            {
                chars[i] = Alphabet[(int)(value % radix)];
                value /= radix;
            }
            return new string(chars);
        }
    }
}
