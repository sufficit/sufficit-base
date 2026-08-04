namespace Sufficit.Contacts
{
    /// <summary>
    /// Canonical names used to persist address fields as contact attributes.
    /// </summary>
    public static class AddressAttributes
    {
        /// <summary>
        /// Modern attribute key. The field name is stored in the description.
        /// </summary>
        public const string ModernKey = "address";

        public const string Code = "code";
        public const string Place = "place";
        public const string Type = "type";
        public const string Number = "number";
        public const string Complement = "complement";
        public const string Region = "region";
        public const string City = "city";
        public const string State = "state";
        public const string Country = "country";
        public const string Extra = "extra";

        public const string LegacyCodeKey = "endereco_cep";
        public const string LegacyPlaceKey = "endereco_logradouro";
        public const string LegacyTypeKey = "endereco_tipo";
        public const string LegacyNumberKey = "endereco_numero";
        public const string LegacyComplementKey = "endereco_complemento";
        public const string LegacyRegionKey = "endereco_bairro";
        public const string LegacyCityKey = "endereco_cidade";
        public const string LegacyStateKey = "endereco_estado";
        public const string LegacyCountryKey = "endereco_pais";
    }
}
