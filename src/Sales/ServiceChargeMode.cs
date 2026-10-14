using System;
using System.Collections.Generic;

namespace Sufficit.Sales;

public enum ServiceChargeMode : byte { Unified = 0, Standalone = 1 }

/// <summary>Generic billing choice stored alongside the contract's existing parameters.</summary>
public static class ServiceChargeConfiguration
{
    public const string Key = "billing.chargeMode";
    public static ServiceChargeMode Read(IReadOnlyDictionary<string, string> values)
    {
        if (!values.TryGetValue(Key, out var mode) || string.IsNullOrWhiteSpace(mode) || mode == "unified")
            return ServiceChargeMode.Unified;
        if (mode == "standalone") return ServiceChargeMode.Standalone;
        throw new InvalidOperationException("Forma de cobrança inválida. Selecione unificada ou avulsa.");
    }
    public static void Set(IDictionary<string, string> values, ServiceChargeMode mode)
    {
        if (mode == ServiceChargeMode.Unified) values.Remove(Key);
        else if (mode == ServiceChargeMode.Standalone) values[Key] = "standalone";
        else throw new ArgumentOutOfRangeException(nameof(mode));
    }
}
