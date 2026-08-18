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
