using System;

namespace Sufficit.Finance;

/// <summary>
/// Stable contact references used to identify bank-slip providers in the UI.
///
/// The dashboard passes these IDs to <c>ContactAvatar</c>. The avatar is then
/// resolved by the contacts avatar endpoint (and therefore uses the avatar
/// stored for the contact), instead of selecting an icon or an external image
/// based only on the provider code.
/// </summary>
public static class BankSlipProviderContacts
{
    /// <summary>Reserved contact reference for Efí.</summary>
    public static Guid EfiId => Guid.Parse("0198c6a1-1f6e-7c31-8a01-000000000001");

    /// <summary>Reserved contact reference for Asaas.</summary>
    public static Guid AsaasId => Guid.Parse("0198c6a1-1f6e-7c31-8a01-000000000002");

    public static Guid ResolveId(string? provider) => provider?.ToLowerInvariant() switch
    {
        BankSlipProviderCodes.Efi => EfiId,
        BankSlipProviderCodes.Asaas => AsaasId,
        _ => Guid.Empty
    };
}
