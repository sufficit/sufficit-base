using System;

namespace Sufficit.Finance;

/// <summary>
/// Defaults for issuer resolution. New automatic charges use the stable
/// Sufficit contact, while historical rows without an issuer keep Guid.Empty
/// so the database records that the original user is unknown.
/// </summary>
public static class BankSlipIssuerDefaults
{
    /// <summary>
    /// Explicit marker for historical rows whose issuer cannot be recovered.
    /// It is persisted as a required all-zero binary GUID.
    /// </summary>
    public static Guid UnknownIssuerId => Guid.Empty;

    /// <summary>
    /// Contato da Sufficit usado como emissor técnico de sistema.
    /// </summary>
    public static Guid SystemIssuerId => OSInformation.SufficitId;

    /// <summary>
    /// Contato técnico usado quando a carga é importada automaticamente da
    /// tabela de boletos legada. O identificador é estável para que o avatar
    /// e o título possam ser resolvidos como qualquer outro contato.
    /// </summary>
    public static Guid LegacyImportIssuerId
        => Guid.Parse("de28dcec-b80e-55d3-bc62-05416c0a67f7");

    public const string LegacyImportIssuerTitle =
        "Boleto - Importacao automatica legado";

    /// <summary>
    /// Contato técnico usado quando um callback de uma cobrança legada cria o
    /// registro canônico pela primeira vez.
    /// </summary>
    public static Guid LegacyCallbackImportIssuerId
        => Guid.Parse("18614fd3-d4f4-51d0-9c6a-9651bc85593c");

    public const string LegacyCallbackImportIssuerTitle =
        "Boleto - Callback automatico legado";

    /// <summary>
    /// Contato técnico usado quando a reconciliação religa um boleto legado a
    /// uma cobrança encontrada no provedor.
    /// </summary>
    public static Guid LegacyRebindIssuerId
        => Guid.Parse("abd2b1cc-5256-5cd0-a12c-827ab2423486");

    public const string LegacyRebindIssuerTitle =
        "Boleto - Reconciliacao automatica legado";

    /// <summary>
    /// URL estável do avatar genérico da Sufficit.
    /// </summary>
    public const string SystemAvatarUrl =
        "https://endpoints.sufficit.com.br/contact/avatar?contextid=d21cfb04-9d37-473b-837c-67591a26feed";

    /// <summary>
    /// Resolves the identity shown in the UI. Unknown historical issuers use
    /// the generic Sufficit avatar without changing the persisted marker.
    /// </summary>
    public static Guid Resolve(Guid requestedBy)
        => requestedBy == UnknownIssuerId ? SystemIssuerId : requestedBy;
}
