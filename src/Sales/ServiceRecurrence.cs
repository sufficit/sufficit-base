using System;
namespace Sufficit.Sales;

/// <summary>Independent recurrence policy, persisted in audited contract parameters.</summary>
public static class ServiceRecurrence
{
    public const string Key = "billing.recurrence.v1";
    public static bool? Read(Contract contract)
        => contract.ParameterValues.TryGetValue(Key, out var value) ? bool.Parse(value) : null;
    public static void Set(Contract contract, bool recurring)
        => contract.ParameterValues[Key] = recurring ? "true" : "false";
    public static bool IsRecurring(Contract contract, ServiceCatalogItem? catalog = null, bool useCatalogDefaults = false)
    {
        var explicitValue = Read(contract);
        if (explicitValue.HasValue) return explicitValue.Value;
        // Credit validity never establishes a recurring purchase agreement.
        if (!contract.ParameterValues.ContainsKey("billing.recurring-call-credit.v1") &&
            ((contract.Source == ContractSource.LegacySales && contract.Title == Constants.SERVICE_TRUNK_BILLED) ||
             (contract.ParameterValues.ContainsKey("legacy.native_adoption.operation") &&
              (contract.SourceKey ?? "").Contains("|" + Constants.SERVICE_TRUNK_BILLED + "|")))) return false;
        return (useCatalogDefaults ? catalog?.Recurring : null) ?? (catalog == null || catalog.BillingMode == ServiceBillingMode.Recurring);
    }
}
