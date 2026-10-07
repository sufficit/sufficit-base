using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Access;

/// <summary>Sufficit business access recipe; it never grants user claims on its own.</summary>
public sealed class EntitlementPresetProfile
{
    public string Key { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string BestFor { get; set; } = string.Empty;
    public int SortOrder { get; set; }
    public string Version { get; set; } = string.Empty;
    public IReadOnlyList<EntitlementPresetDirective> Directives { get; set; } = Array.Empty<EntitlementPresetDirective>();
}

public sealed class EntitlementPresetDirective
{
    public string Key { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public sealed class SaveEntitlementPreset
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string BestFor { get; set; } = string.Empty;
    public int SortOrder { get; set; }
    public IReadOnlyList<EntitlementPresetDirective> Directives { get; set; } = Array.Empty<EntitlementPresetDirective>();
    public string? Version { get; set; }
}

public sealed class SaveEntitlementPresetItem
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
}

public interface IEntitlementPresetStore
{
    Task<IReadOnlyList<EntitlementPresetProfile>> List(CancellationToken token);
    Task<EntitlementPresetProfile?> Get(string key, CancellationToken token);
    Task<EntitlementPresetProfile> Save(string key, SaveEntitlementPreset request, bool create, CancellationToken token);
    Task Delete(string key, string version, CancellationToken token);
    Task<EntitlementPresetProfile> SaveItem(string key, string directiveKey, SaveEntitlementPresetItem request, CancellationToken token);
    Task<EntitlementPresetProfile> DeleteItem(string key, string directiveKey, string version, CancellationToken token);
}

public sealed class EntitlementPresetConflictException : InvalidOperationException
{
    public EntitlementPresetConflictException(string message) : base(message) { }
}
public sealed class EntitlementPresetNotFoundException : InvalidOperationException
{
    public EntitlementPresetNotFoundException() : base("Preset or item not found.") { }
}
