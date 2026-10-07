using System;
using System.Text.Json;

namespace Sufficit.Sales;

/// <summary>Validates an initial historical start-only correction; immutable receipt replay remains provider-owned.</summary>
public static class HistoricalStartCorrectionPolicy
{
    public static void Validate(LegacyServiceEditorState opened, LegacyServiceChange command)
    {
        if (command.Action != "save" || command.ContractId != Guid.Empty || opened.ContractId != Guid.Empty ||
            command.Desired == null || opened.Service.Id != command.ServiceId ||
            opened.Service.ContextId != command.Desired.ContextId || string.IsNullOrWhiteSpace(command.Reason) ||
            command.Reason.Trim().Length < 5 || command.Reason.Length > 1000)
            throw new ArgumentException("A historical start correction requires an explicit reason and historical service.");
        var desired = JsonSerializer.Deserialize<SalesRecord>(JsonSerializer.Serialize(command.Desired))!;
        var start = desired.Start;
        desired.Start = opened.Service.Start;
        if (JsonSerializer.Serialize(desired) != JsonSerializer.Serialize(opened.Service) ||
            start == opened.Service.Start || start.Kind != DateTimeKind.Utc || start > opened.Service.End)
            throw new ArgumentException("Only the historical start date may be changed by this command.");
    }
}
