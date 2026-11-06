using System;
using System.Globalization;

namespace Sufficit.Sales;

public enum ServiceBillingIntervalUnit : byte { Months = 0, Days = 1 }

/// <summary>Calendar billing cadence. Contract overrides belong to audited parameters; absent overrides retain legacy months.</summary>
public sealed class ServiceBillingInterval
{
    public const string Key = "billing.interval.v1";
    public uint Count { get; }
    public ServiceBillingIntervalUnit Unit { get; }
    public ServiceBillingInterval(uint count, ServiceBillingIntervalUnit unit)
    {
        if (unit != ServiceBillingIntervalUnit.Months && unit != ServiceBillingIntervalUnit.Days)
            throw new ArgumentOutOfRangeException(nameof(unit));
        if (count < 1 || count > (unit == ServiceBillingIntervalUnit.Months ? 120u : 3660u))
            throw new ArgumentOutOfRangeException(nameof(count), "Use 1–120 meses ou 1–3660 dias.");
        Count = count; Unit = unit;
    }
    public static ServiceBillingInterval Read(Contract contract)
    {
        if (!contract.ParameterValues.TryGetValue(Key, out var value))
            return new ServiceBillingInterval(contract.BillingCycleMonths, ServiceBillingIntervalUnit.Months);
        var parts = value.Split(':');
        if (parts.Length != 2 || !Enum.TryParse<ServiceBillingIntervalUnit>(parts[0], out var unit)
            || !uint.TryParse(parts[1], NumberStyles.None, CultureInfo.InvariantCulture, out var count))
            throw new ArgumentException("Invalid billing interval.");
        return new ServiceBillingInterval(count, unit);
    }
    public static ServiceBillingInterval Read(ServiceCatalogItem item)
        => new ServiceBillingInterval(item.BillingIntervalCount ?? item.BillingCycleMonths,
            item.BillingIntervalUnit ?? ServiceBillingIntervalUnit.Months);
    public static void Set(Contract contract, uint count, ServiceBillingIntervalUnit unit)
    {
        var interval = new ServiceBillingInterval(count, unit);
        contract.ParameterValues[Key] = interval.Unit + ":" + interval.Count.ToString(CultureInfo.InvariantCulture);
        // Old consumers retain a valid compatibility value, never a day count disguised as months.
        contract.BillingCycleMonths = unit == ServiceBillingIntervalUnit.Months ? count : 1;
    }
    public static bool IsValid(Contract contract)
    {
        try { Read(contract); return true; } catch (ArgumentException) { return false; }
    }
    public bool SameAs(ServiceBillingInterval other) => Count == other.Count && Unit == other.Unit;
    public DateTime Advance(DateTime anchor, int cycles = 1, int? dayOfMonth = null)
    {
        var offset = checked((int)Count * cycles);
        if (Unit == ServiceBillingIntervalUnit.Days) return anchor.AddDays(offset);
        var target = anchor.AddMonths(offset);
        var day = Math.Min(dayOfMonth ?? anchor.Day, DateTime.DaysInMonth(target.Year, target.Month));
        return new DateTime(target.Year, target.Month, day, 0, 0, 0, anchor.Kind);
    }
    public (DateTime Start, DateTime End) Bounds(DateTime anchor, DateTime reference, int? dayOfMonth = null)
    {
        var distance = Unit == ServiceBillingIntervalUnit.Days ? (reference.Date - anchor.Date).Days
            : (reference.Year - anchor.Year) * 12 + reference.Month - anchor.Month;
        var index = Math.Max(0, distance) / (int)Count;
        var start = Advance(anchor, index, dayOfMonth);
        if (start > reference && index > 0) start = Advance(anchor, --index, dayOfMonth);
        return (start, Advance(anchor, index + 1, dayOfMonth));
    }
}
