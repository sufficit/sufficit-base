using System;

namespace Sufficit.Finance;

/// <summary>
/// Identidade usada quando uma cobrança foi criada por uma rotina do sistema
/// e o usuário humano não foi preservado pela origem. O valor é um contato
/// estável da Sufficit, portanto também fornece um avatar genérico consistente.
/// </summary>
public static class BankSlipIssuerDefaults
{
    /// <summary>
    /// Contato da Sufficit usado como emissor técnico de sistema.
    /// </summary>
    public static Guid SystemIssuerId => OSInformation.SufficitId;

    /// <summary>
    /// URL estável do avatar genérico da Sufficit.
    /// </summary>
    public const string SystemAvatarUrl =
        "https://endpoints.sufficit.com.br/contact/avatar?contextid=d21cfb04-9d37-473b-837c-67591a26feed";

    public static Guid Resolve(Guid requestedBy)
        => requestedBy == Guid.Empty ? SystemIssuerId : requestedBy;
}
