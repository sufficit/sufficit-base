namespace Sufficit.Telephony
{
    /// <summary>Kinds of <see cref="EndPointAlias"/>.</summary>
    public static class EndPointAliasKind
    {
        /// <summary>Context-scoped dial shortcut (e.g. "6007"); may repeat across customers.</summary>
        public const string Dial = "dial";

        /// <summary>
        ///     Alternative PJSIP registration name of the extension, unique across the system. It
        ///     authenticates with the extension password and registers into the extension GUID AOR.
        /// </summary>
        public const string Login = "login";
    }
}
