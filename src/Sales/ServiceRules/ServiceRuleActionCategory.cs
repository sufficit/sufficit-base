namespace Sufficit.Sales
{
    /// <summary>Effect class of an action, used for validation and presentation.</summary>
    public enum ServiceRuleActionCategory : byte
    {
        /// <summary>Informs someone; never changes the service.</summary>
        Notification = 0,

        /// <summary>Restricts the service and is undone by payment.</summary>
        Restriction = 1,

        /// <summary>Ends the service; cannot be undone.</summary>
        Termination = 2,

        /// <summary>Operational step without customer-visible restriction (export, archive).</summary>
        Operation = 3
    }
}
