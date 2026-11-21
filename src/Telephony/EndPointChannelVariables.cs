using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Endpoint channel variables (Asterisk PJSIP "set_var") stored as endpoint properties.
    ///     Generic variables use "pjsip.var.NAME" = value; known variables have a dedicated property.
    ///     Shared by the realtime service (validation, serialization) and the management screens.
    /// </summary>
    public static class EndPointChannelVariables
    {
        /// <summary>Property key prefix of generic variables: "pjsip.var.NAME".</summary>
        public const string Prefix = "pjsip.var.";

        /// <summary>Per-extension media of calls relayed by another voip node: "direct" or "relay".</summary>
        public const string NodeRelayMediaKey = "pjsip.node_relay_media";

        /// <summary>Channel variable read by the node relay dialplan.</summary>
        public const string NodeRelayMediaVariable = "SUFFICIT_NODE_RELAY_MEDIA";

        /// <summary>Accepted values of <see cref="NodeRelayMediaKey"/>.</summary>
        public static readonly IReadOnlyList<string> NodeRelayMediaValues = new[] { "direct", "relay" };

        /// <summary>Maximum value length of a generic variable.</summary>
        public const int MaxValueLength = 256;

        private static readonly Regex NamePattern = new Regex("^[A-Za-z_][A-Za-z0-9_]{0,63}$", RegexOptions.CultureInvariant);

        /// <summary>Variables with a dedicated property; they cannot be set as generic variables.</summary>
        public static readonly IReadOnlyDictionary<string, string> Reserved = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            [NodeRelayMediaVariable] = NodeRelayMediaKey,
        };

        public static bool IsVariableKey(string? key) => key != null && key.StartsWith(Prefix, StringComparison.Ordinal);

        public static string ToKey(string name) => Prefix + name;

        public static string ToName(string key) => key.Substring(Prefix.Length);

        /// <summary>Letters, digits and underscore, not starting with a digit, up to 64 chars, not reserved.</summary>
        public static bool IsValidName(string? name)
            => name != null && NamePattern.IsMatch(name) && !Reserved.ContainsKey(name);

        /// <summary>1 to 256 chars, without the separators of the realtime protocol (&amp; % newline).</summary>
        public static bool IsValidValue(string? value)
            => !string.IsNullOrEmpty(value) && value!.Length <= MaxValueLength
               && value.IndexOfAny(new[] { '&', '%', '\n', '\r', '\0' }) < 0;
    }
}
