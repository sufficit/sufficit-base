using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sufficit.Telephony.DIDs.Testing
{
    /// <summary>A DID of the Sufficit context: the only numbers allowed as test caller ids.</summary>
    public class DIDTestOwnNumber
    {
        public string Extension { get; set; } = string.Empty;

        /// <summary>Carrier of the number (<c>suff_did.fornecedor</c>); an origin leaves through its own number's carrier.</summary>
        public Guid ProviderId { get; set; }
    }

    /// <summary>What the PBX list should hold now, and the origins left out of it.</summary>
    public class DIDTestCallerIdList
    {
        /// <summary>Value of the Asterisk global: suffixes joined by |, empty when nothing is valid.</summary>
        public string Value { get; set; } = string.Empty;

        public IReadOnlyList<DIDTestOrigin> Dropped { get; set; } = Array.Empty<DIDTestOrigin>();
    }

    /// <summary>
    /// Validation shared by API, worker and screen. The PBX stops every inbound call whose caller id ends with a listed
    /// suffix, so a wrong value silently hangs up customer calls: everything that reaches that list passes here.
    /// </summary>
    public static class DIDTestRules
    {
        /// <summary>Asterisk global read by <c>from-external</c>.</summary>
        public const string CallerIdGlobal = "DID_TEST_CLIS";

        /// <summary>Digits compared at the end of the inbound caller id; carriers deliver the same number with 55, 00 or nothing in front.</summary>
        public const int CallerIdSuffixLength = 10;

        public const int MinNumberLength = 10;
        public const int MaxNumberLength = 15;
        public const int MaxTitleLength = 80;

        private static readonly Regex TrunkFormat = new Regex("^[A-Za-z0-9_-]{1,64}$", RegexOptions.Compiled);
        private static readonly Regex PrefixFormat = new Regex("^[0-9]{0,16}$", RegexOptions.Compiled);
        private static readonly Regex ListSeparators = new Regex("[\\r\\n,;\\t]+", RegexOptions.Compiled);
        private static readonly Regex Spaces = new Regex("\\s+", RegexOptions.Compiled);

        /// <summary>
        /// Full E.164 digits of a number in any common format, or null when it cannot be a phone number. Written without
        /// + the Brazilian national forms are completed with 55; a foreign number needs its +.
        /// </summary>
        public static string? Normalize(string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            var text = input!.Trim();
            var international = text.StartsWith("+", StringComparison.Ordinal);
            var builder = new StringBuilder(text.Length);
            foreach (var character in text)
            {
                if (character >= '0' && character <= '9') builder.Append(character);
                else if (char.IsLetter(character)) return null;
            }

            var digits = builder.ToString();
            if (!international)
            {
                if (digits.StartsWith("00", StringComparison.Ordinal)) { digits = digits.Substring(2); international = true; }
                else if (digits.StartsWith("0800", StringComparison.Ordinal) && digits.Length == 11) digits = "55" + digits.Substring(1);
                else if (digits.StartsWith("0", StringComparison.Ordinal)) digits = digits.Substring(1);
            }

            // A full Brazilian E.164 number has at least 12 digits, so 10 or 11 is national even when the area code is 55.
            if (!international && (digits.Length == 10 || digits.Length == 11))
                digits = "55" + digits;

            if (digits.Length < MinNumberLength || digits.Length > MaxNumberLength || digits[0] == '0') return null;
            return digits;
        }

        /// <summary>Splits a pasted list by line, comma, semicolon or tab; a line with spaces is one number unless that makes no phone number.</summary>
        public static IReadOnlyList<string> SplitList(string? input)
        {
            var result = new List<string>();
            if (string.IsNullOrWhiteSpace(input)) return result;
            foreach (var part in ListSeparators.Split(input!))
            {
                var entry = part.Trim();
                if (entry.Length == 0) continue;
                if (Normalize(entry) != null) { result.Add(entry); continue; }
                result.AddRange(Spaces.Split(entry));
            }
            return result;
        }

        /// <summary>Ends of a pasted list: distinct valid numbers, in order, and what could not be read.</summary>
        public static void ParseList(string? input, out IReadOnlyList<string> numbers, out IReadOnlyList<DIDTestRejectedNumber> rejected)
        {
            var valid = new List<string>();
            var invalid = new List<DIDTestRejectedNumber>();
            var seen = new HashSet<string>(StringComparer.Ordinal);
            foreach (var entry in SplitList(input))
            {
                var number = Normalize(entry);
                if (number == null) invalid.Add(new DIDTestRejectedNumber { Input = entry, Reason = DIDTestErrors.InvalidNumber });
                else if (seen.Add(number)) valid.Add(number);
            }
            numbers = valid;
            rejected = invalid;
        }

        /// <summary>Same phone number, tolerating the prefixes carriers put or remove in front of it.</summary>
        public static bool SameNumber(string? left, string? right)
        {
            var a = Digits(left); var b = Digits(right);
            return a.Length >= CallerIdSuffixLength && b.Length >= CallerIdSuffixLength && CallerIdSuffix(a) == CallerIdSuffix(b);
        }

        /// <summary>Ending of a number as the PBX compares it.</summary>
        public static string CallerIdSuffix(string number)
        {
            var digits = Digits(number);
            return digits.Length <= CallerIdSuffixLength ? digits : digits.Substring(digits.Length - CallerIdSuffixLength);
        }

        private static string Digits(string? value) => value == null ? string.Empty : new string(value.Where(c => c >= '0' && c <= '9').ToArray());

        /// <summary>Is this list value something the dialplan accepts? Mirrors the check in <c>from-external</c>.</summary>
        public static bool IsValidCallerIdValue(string? value)
            => value != null && Regex.IsMatch(value, "^[0-9]{10,}([|][0-9]{10,})*\\z");

        public static bool IsOwnNumber(string? number, IEnumerable<DIDTestOwnNumber> ownNumbers)
        {
            var digits = Normalize(number);
            return digits != null && ownNumbers.Any(own => Normalize(own.Extension) == digits);
        }

        /// <summary>The PBX list for these origins. Keeps only enabled origins whose number is a DID of the Sufficit context.</summary>
        public static DIDTestCallerIdList BuildCallerIdList(IEnumerable<DIDTestOrigin> origins, IEnumerable<DIDTestOwnNumber> ownNumbers)
        {
            var own = ownNumbers.ToList();
            var dropped = new List<DIDTestOrigin>();
            var suffixes = new SortedSet<string>(StringComparer.Ordinal);
            foreach (var origin in origins.Where(o => o.Enabled))
            {
                if (IsOwnNumber(origin.Number, own)) suffixes.Add(CallerIdSuffix(Normalize(origin.Number)!));
                else dropped.Add(origin);
            }
            return new DIDTestCallerIdList { Value = string.Join("|", suffixes), Dropped = dropped };
        }

        /// <summary>Does a live PBX value cover this number? An invalid value covers nothing: the dialplan ignores it too.</summary>
        public static bool CallerIdListCovers(string? value, string number)
            => IsValidCallerIdValue(value) && value!.Split('|').Contains(CallerIdSuffix(number));

        /// <summary>
        /// Is this number among the usernames of the live registrations? Read them from AMI SIPshowregistry: the CLI
        /// <c>sip show registry</c> cuts the username at 12 characters, which hides every 13-digit number.
        /// </summary>
        public static bool RegistryContains(IEnumerable<string>? registered, string did)
        {
            if (registered == null) return false;
            var national = did.StartsWith("55", StringComparison.Ordinal) ? did.Substring(2) : did;
            return registered.Any(username => username == did || username == national);
        }

        /// <summary>Normalizes an origin in place and returns what is wrong with it in Brazilian Portuguese, or null.</summary>
        public static string? ValidateOrigin(DIDTestOrigin origin, IEnumerable<DIDTestOwnNumber> ownNumbers)
        {
            if (string.IsNullOrWhiteSpace(origin.Title)) return "Informe um título.";
            origin.Title = origin.Title.Trim();
            if (origin.Title.Length > MaxTitleLength) return $"O título aceita no máximo {MaxTitleLength} caracteres.";

            var number = Normalize(origin.Number);
            if (number == null) return $"Informe o número completo, com pelo menos {MinNumberLength} dígitos.";
            if (!IsOwnNumber(number, ownNumbers)) return "O número precisa ser um DID da Sufficit.";
            origin.Number = number;

            origin.Trunk = string.IsNullOrWhiteSpace(origin.Trunk) ? null : origin.Trunk!.Trim();
            origin.Prefix = string.IsNullOrWhiteSpace(origin.Prefix) ? null : origin.Prefix!.Trim();
            if (origin.Trunk != null && !TrunkFormat.IsMatch(origin.Trunk)) return "O tronco aceita apenas letras, números, hífen e sublinhado.";
            if (origin.Prefix != null && !PrefixFormat.IsMatch(origin.Prefix)) return "O prefixo aceita apenas dígitos, no máximo 16.";
            if (origin.Enabled && origin.Trunk == null) return "Informe o tronco para ativar esta bina.";
            if (origin.Priority < 0 || origin.Priority > 9999) return "A prioridade deve estar entre 0 e 9999.";
            return null;
        }

        /// <summary>What is wrong with the settings in Brazilian Portuguese, or null.</summary>
        public static string? ValidateSettings(DIDTestSettings settings)
        {
            string? Range(int value, int min, int max, string label)
                => value < min || value > max ? $"{label} deve estar entre {min} e {max}." : null;

            var error = Range(settings.RingSeconds, 5, 120, "O tempo de toque")
                ?? Range(settings.AttemptsPerDid, 1, 5, "O número de tentativas")
                ?? Range(settings.RetrySeconds, 0, 3600, "O intervalo entre tentativas")
                ?? Range(settings.PacingSeconds, 1, 600, "O intervalo entre chamadas")
                ?? Range(settings.MaxConcurrentCalls, 1, 10, "O limite de chamadas simultâneas")
                ?? Range(settings.ArrivalGraceSeconds, 0, 60, "A tolerância de chegada")
                ?? Range(settings.RunTimeoutSeconds, 30, 86400, "O prazo do teste")
                ?? Range(settings.PollSeconds, 1, 300, "O ciclo de verificação")
                ?? Range(settings.SyncSeconds, 5, 3600, "O ciclo de sincronização")
                ?? Range(settings.MaxBatchSize, 1, 1000, "O tamanho máximo da lista")
                ?? Range(settings.RunRetentionDays, 1, 30, "A retenção do histórico");
            if (error != null) return error;

            var required = (settings.RingSeconds + settings.ArrivalGraceSeconds) * settings.AttemptsPerDid
                + settings.RetrySeconds * (settings.AttemptsPerDid - 1);
            return settings.RunTimeoutSeconds < required
                ? $"O prazo do teste precisa ser de pelo menos {required} segundos para caber todas as tentativas."
                : null;
        }
    }
}
