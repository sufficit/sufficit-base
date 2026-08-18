using System;

namespace Sufficit.Finance;

/// <summary>
/// Stable catalog of automated bank-slip issuance types.
///
/// The identifiers are UUID v7 values.  The human-readable code belongs to
/// the lookup table and must not be persisted in a bank-slip row; consumers
/// use the issuer-type identifier and resolve its title/contact from
/// the catalog.
/// </summary>
public static class BankSlipIssuerTypeCatalog
{
    /// <summary>Importação de boletos da tabela MSSQL legada.</summary>
    public static Guid LegacyImportId
        => Guid.Parse("01a01605-322d-779f-8904-8f236d6aec80");

    /// <summary>Criação do boleto ao receber callback de cobrança legada.</summary>
    public static Guid LegacyCallbackImportId
        => Guid.Parse("01a01605-322e-72e4-b2c4-0cf46c0580d7");

    /// <summary>Religação do boleto feita pela reconciliação do provedor.</summary>
    public static Guid LegacyRebindId
        => Guid.Parse("01a01605-322f-7f06-b089-4454dc99e57f");

    public const string LegacyImportCode = "legacy_import";
    public const string LegacyCallbackImportCode = "legacy_callback_import";
    public const string LegacyRebindCode = "legacy_rebind";

    public const string LegacyImportTitle =
        "Boleto - Importacao automatica legado";

    public const string LegacyCallbackImportTitle =
        "Boleto - Callback automatico legado";

    public const string LegacyRebindTitle =
        "Boleto - Reconciliacao automatica legado";
}
