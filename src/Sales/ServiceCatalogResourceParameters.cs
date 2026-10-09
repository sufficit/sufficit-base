using System;
using System.Globalization;

namespace Sufficit.Sales;

/// <summary>Generic validation shared by catalog persistence and entitlement adapters.</summary>
public static class ServiceCatalogResourceParameters
{
    public static long Units(decimal value, long scale)
    {
        if (value < 0 || scale <= 0) throw new InvalidOperationException("Invalid resource units.");
        var units = checked(value * scale);
        if (units != decimal.Truncate(units) || units > long.MaxValue)
            throw new InvalidOperationException("Resource units must be exact integers.");
        return (long)units;
    }
    public static decimal Basis(ServiceCatalogParameterDefinition p)
        => decimal.TryParse(p.DefaultValue, NumberStyles.Number, CultureInfo.InvariantCulture, out var v) ? v
            : throw new InvalidOperationException("Resource default is required.");
    public static void Validate(ServiceCatalogParameterDefinition p)
    {
        if (!Enum.IsDefined(typeof(ServiceParameterResourceKind), p.ResourceKind))
            throw new InvalidOperationException("Invalid resource kind.");
        if (p.ResourceKind == ServiceParameterResourceKind.None) return;
        if (p.Type != ServiceParameterType.Integer && p.Type != ServiceParameterType.Decimal)
            throw new InvalidOperationException("Resources require a numeric parameter.");
        var basis = Basis(p);
        if (!p.Maximum.HasValue || basis < (p.Minimum ?? 0) || basis > p.Maximum || p.Increment <= 0 || p.PricePerIncrement < 0
            || p.PricePerIncrement * 100 != decimal.Truncate(p.PricePerIncrement * 100))
            throw new InvalidOperationException("Resource default, range, increment or price is invalid.");
        Units(basis, p.StorageScale); Units(p.Maximum.Value, p.StorageScale);
        if (Units(p.Increment, p.StorageScale) <= 0 || (p.Maximum.Value - basis) % p.Increment != 0)
            throw new InvalidOperationException("Resource range must follow its increment.");
    }
}
