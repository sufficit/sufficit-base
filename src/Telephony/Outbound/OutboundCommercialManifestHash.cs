using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>Stable digest of complete source line versions; independent of local row IDs.</summary>
    public static class OutboundCommercialManifestHash
    {
        public static string Compute(IEnumerable<OutboundCommercialSourceManifestLine> lines)
        {
            if (lines == null) throw new ArgumentNullException(nameof(lines));
            var buffer = new StringBuilder();
            foreach (var line in lines.OrderBy(item => item.ExternalContractLineId, StringComparer.Ordinal))
            {
                Append(buffer, line.ExternalContractLineId);
                Append(buffer, line.SourceVersion.ToString(CultureInfo.InvariantCulture));
                Append(buffer, line.PayloadHash ?? string.Empty);
            }
            using var sha = SHA256.Create();
            var digest = sha.ComputeHash(Encoding.UTF8.GetBytes(buffer.ToString()));
            var result = new StringBuilder(digest.Length * 2);
            foreach (var value in digest)
                result.Append(value.ToString("x2", CultureInfo.InvariantCulture));
            return result.ToString();
        }

        private static void Append(StringBuilder buffer, string value)
        {
            buffer.Append(value.Length.ToString(CultureInfo.InvariantCulture));
            buffer.Append(':');
            buffer.Append(value);
        }
    }
}
