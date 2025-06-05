using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Asterisk
{
    /// <summary>
    ///     UniqueId and LinkedId from asterisk
    /// </summary>
    public class AsteriskCallDetailsId
    {
        /// <summary>
        /// Regex to get groups from default string. Server, Timestamp and Sequence
        /// </summary>
        public const string REGEX = @"((?<server>\S+)-)?(?<timestamp>\d+)\.(?<sequence>\d+)";

        public string? Server { get; set; }

        public string Timestamp { get; set; } = default!;

        public string Sequence { get; set; } = default!;

        public override string ToString()
            => Server != null ? $"{Server}-{Timestamp}.{Sequence}" : $"{Timestamp}.{Sequence}";
    }
}
