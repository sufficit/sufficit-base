using System;

namespace Sufficit.Telephony.DIDs;

/// <summary>Frozen telephony-owned command derived from verified local coverage, not a sales instruction.</summary>
public sealed class DIDBindingCommand
{
    public Guid EventId { get; set; }
    public long CoverageVersion { get; set; }
    public Guid ContractId { get; set; }
    public Guid DidId { get; set; }
    public Guid ContextId { get; set; }
    public string ExpectedExtension { get; set; } = string.Empty;
    public string? ExpectedDestination { get; set; }
    public string Destination { get; set; } = string.Empty;
}
