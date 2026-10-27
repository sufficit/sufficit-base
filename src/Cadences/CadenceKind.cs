namespace Sufficit.Cadences
{
    /// <summary>Main purpose of a cadence; each step still declares its own action.</summary>
    public enum CadenceKind : byte
    {
        /// <summary>Reminders and alerts only; never restricts anything.</summary>
        Notification = 0,

        /// <summary>Dunning: reminders followed by blocking, suspension or closing.</summary>
        CutOff = 1,

        /// <summary>Operational controls driven by dates (quotas, features, reviews).</summary>
        Control = 2
    }
}
