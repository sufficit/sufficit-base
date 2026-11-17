using System;
using System.Text.RegularExpressions;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>Reserved outbound selectors enabled only for the Sufficit test context.</summary>
    public static class OutboundPilotDialing
    {
        public static readonly Guid ContextId = new Guid("d21cfb04-9d37-473b-837c-67591a26feed");
        public const string SipPrefix = "*91";
        public const string WhatsAppPrefix = "*92";
        private static readonly Regex PublicNumber = new Regex(@"\A[1-9][0-9]{7,14}\z", RegexOptions.CultureInvariant);

        public static bool IsPublicNumber(string? number)
            => number != null && PublicNumber.IsMatch(number);

        public static bool TryParse(string input, out string prefix, out string destination)
        {
            prefix = input.Length >= 3 ? input.Substring(0, 3) : string.Empty;
            destination = input;
            if (prefix != SipPrefix && prefix != WhatsAppPrefix)
                return false;

            var digits = input.Substring(3);
            if (digits.StartsWith("+", StringComparison.Ordinal))
                digits = digits.Substring(1);
            if (!IsPublicNumber(digits))
                return false;

            destination = "+" + digits;
            return true;
        }
    }
}
