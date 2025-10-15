using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Cache utilities used in Sufficit.Telephony
    /// </summary>
    /// <remarks>
    ///     Use: using static Sufficit.Telephony.Caching;
    ///     Then access: IVRCache.Module, IVRCache.BuildIdKey(id), etc.
    /// </remarks>
    public static class Caching
    {
        public static class IVRCache
        {
            public const string Module = "ivr";

            public const string IdPrefix = "id:";
            public const string ExtensionPrefix = "ext:";
            public const string OptionsPrefix = "options:";

            public static string BuildIdKey(Guid ivrId) => $"{IdPrefix}{ivrId:N}";
            public static string BuildExtensionKey(Guid contextId, string extension) => $"{ExtensionPrefix}{contextId:N}:{extension}";
            public static string BuildOptionsKey(Guid ivrId) => $"{OptionsPrefix}{ivrId:N}";
        }
    }
}
