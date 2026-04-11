namespace Sufficit.Telefonia.Classifier
{
    /// <summary>
    /// Canonical Brazilian federative-unit identifiers used by legacy telephony classifiers.
    /// The enum numeric value is only the canonical area code for the state.
    /// For the complete mapping between DDDs and states, use <see cref="BrazilAreaCodeMap"/>.
    /// </summary>
    public enum RegionsOfBrazil
    {
        /// <summary>
        /// Unknown or not classified.
        /// </summary>
        UNKNOWN = 0,

        ACRE = 68,
        ALAGOAS = 82,
        AMAPA = 96,
        AMAZONAS = 92,
        BAHIA = 71,
        CEARA = 85,
        DISTRITO_FEDERAL = 61,
        ESPIRITO_SANTO = 27,
        GOIAS = 62,
        MARANHAO = 98,
        MATO_GROSSO = 65,
        MATO_GROSSO_DO_SUL = 67,
        MINAS_GERAIS = 31,
        PARA = 91,
        PARAIBA = 83,
        PARANA = 41,
        PERNAMBUCO = 81,
        PIAUI = 86,
        RIO_DE_JANEIRO = 21,
        RIO_GRANDE_DO_NORTE = 84,
        RIO_GRANDE_DO_SUL = 51,
        RONDONIA = 69,
        RORAIMA = 95,
        SANTA_CATARINA = 47,
        SAO_PAULO = 11,
        SERGIPE = 79,
        TOCANTINS = 63
    }
}
