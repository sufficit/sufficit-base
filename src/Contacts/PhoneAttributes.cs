namespace Sufficit.Contacts
{
    /// <summary>
    /// Canonical names used to persist phone numbers as contact attributes.
    /// </summary>
    public static class PhoneAttributes
    {
        /// <summary>
        /// Modern attribute key. The phone kind is stored in the description.
        /// </summary>
        public const string ModernKey = Attributes.Phone;

        public const string CellularDescription = Attributes.Cellular;

        public const string BusinessDescription = Attributes.Business;

        /// <summary>
        /// Legacy key that stored a mobile phone directly in the attribute value.
        /// </summary>
        public const string LegacyCellularKey = Attributes.Cellular;

        /// <summary>
        /// Legacy key that stored a business/fixed phone directly in the value.
        /// </summary>
        public const string LegacyBusinessPhoneKey = Attributes.BusinessPhone;
    }
}
