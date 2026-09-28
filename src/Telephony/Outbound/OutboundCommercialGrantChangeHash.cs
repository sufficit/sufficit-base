using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>Stable SHA-256 of the full-state payload, excluding the delivery event ID.</summary>
    public static class OutboundCommercialGrantChangeHash
    {
        public static string Compute(OutboundCommercialGrantChange change)
        {
            if (change == null)
                throw new ArgumentNullException(nameof(change));

            var text = new StringBuilder();
            Append(text, change.SchemaVersion.ToString(CultureInfo.InvariantCulture));
            Append(text, change.SourceSystem);
            Append(text, change.ExternalContractLineId);
            Append(text, change.ContextId.ToString("N"));
            Append(text, change.ServiceId.ToString("N"));
            Append(text, change.SourceVersion.ToString(CultureInfo.InvariantCulture));
            Append(text, change.EffectiveAtUtc.ToString("O", CultureInfo.InvariantCulture));
            Append(text, change.StartUtc.ToString("O", CultureInfo.InvariantCulture));
            Append(text, change.ExpirationUtc.ToString("O", CultureInfo.InvariantCulture));
            Append(text, change.Channels.ToString(CultureInfo.InvariantCulture));
            Append(text, ((int)change.AdministrativeState).ToString(CultureInfo.InvariantCulture));
            Append(text, ((int)change.Kind).ToString(CultureInfo.InvariantCulture));
            using var sha = SHA256.Create();
            var digest = sha.ComputeHash(Encoding.UTF8.GetBytes(text.ToString()));
            var result = new StringBuilder(digest.Length * 2);
            foreach (var value in digest)
                result.Append(value.ToString("x2", CultureInfo.InvariantCulture));
            return result.ToString();
        }

        private static void Append(StringBuilder buffer, string? value)
        {
            value ??= string.Empty;
            buffer.Append(value.Length.ToString(CultureInfo.InvariantCulture));
            buffer.Append(':');
            buffer.Append(value);
        }
    }
}
