using System;

namespace Sufficit
{
    /// <summary>
    ///     System constants properties
    /// </summary>
    public class OSInformation
    {
        public const string Title = "Sufficit Operacional Services";

        public const string SufficitIdString = "d21cfb04-9d37-473b-837c-67591a26feed";

        public static Guid SufficitId { get; } = Guid.Parse(SufficitIdString);

        [Obsolete]
        public static Guid IDSufficit => SufficitId;
    }
}
