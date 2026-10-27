namespace Sufficit.Cadences
{
    /// <summary>Who receives or is affected by one step.</summary>
    public enum CadenceAudience : byte
    {
        /// <summary>Customer contacts (financial, technical, subscribers of the event).</summary>
        Customer = 0,

        /// <summary>Administrators of the affected account or resource.</summary>
        AccountAdministrators = 1,

        /// <summary>Every user of the affected account or resource.</summary>
        AccountUsers = 2,

        /// <summary>Sufficit staff.</summary>
        Internal = 3
    }
}
