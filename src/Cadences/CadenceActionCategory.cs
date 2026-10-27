namespace Sufficit.Cadences
{
    /// <summary>Effect class of an action, used for validation and presentation.</summary>
    public enum CadenceActionCategory : byte
    {
        /// <summary>Informs someone; never changes the service.</summary>
        Notification = 0,

        /// <summary>Restricts something and is undone when the case is resolved (e.g. payment).</summary>
        Restriction = 1,

        /// <summary>Ends something; cannot be undone.</summary>
        Termination = 2,

        /// <summary>Internal operation without customer-visible effect (export, archive, review).</summary>
        Operation = 3
    }
}
