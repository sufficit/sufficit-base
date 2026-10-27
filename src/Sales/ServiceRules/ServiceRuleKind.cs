namespace Sufficit.Sales
{
    /// <summary>Main purpose of a schedule; each step still declares its own action.</summary>
    public enum ServiceRuleKind : byte
    {
        /// <summary>Reminders and alerts only; never restricts the service.</summary>
        Notification = 0,

        /// <summary>Dunning: reminders followed by blocking, suspension or closing.</summary>
        CutOff = 1,

        /// <summary>Operational service controls driven by dates (e.g. quota or feature toggles).</summary>
        Control = 2
    }
}
