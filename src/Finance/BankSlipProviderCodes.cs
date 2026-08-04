using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Provides stable provider codes persisted by the bank slip domain.
    /// </summary>
    public static class BankSlipProviderCodes
    {
        public const string Efi = "efi";
        public const string Asaas = "asaas";

        public static bool IsKnown(string providerCode)
            => string.Equals(providerCode, Efi, StringComparison.OrdinalIgnoreCase)
            || string.Equals(providerCode, Asaas, StringComparison.OrdinalIgnoreCase);
    }
}
