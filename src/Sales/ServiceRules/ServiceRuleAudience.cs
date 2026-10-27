namespace Sufficit.Sales
{
    /// <summary>Who receives or is affected by one step.</summary>
    public enum ServiceRuleAudience : byte
    {
        /// <summary>Financial/contact recipients of the customer.</summary>
        Customer = 0,

        /// <summary>Administrators of the consumer account (e.g. Hermes account admins).</summary>
        AccountAdministrators = 1,

        /// <summary>Every user of the consumer account.</summary>
        AccountUsers = 2,

        /// <summary>Sufficit staff (sales, finance, support).</summary>
        Internal = 3
    }
}
